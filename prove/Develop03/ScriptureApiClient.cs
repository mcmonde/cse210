using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ScriptureApiClient
{
    private readonly HttpClient _client;

    public ScriptureApiClient()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://openscriptureapi.org/api/scriptures/v1/lds/en/volume/"); // Replace with actual API base URL
    }

    public async Task<string> GetScriptureTextAsync(Reference reference)
    {
        try
        {
            string endpoint = $"scriptures/{reference.GetBook()}/{reference.GetChapter()}";
            HttpResponseMessage response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var chapterResponse = await JsonSerializer.DeserializeAsync<ChapterResponse>(responseStream, options);

                Verse[] selectedVerses = GetVersesInRange(chapterResponse, reference.GetStartVerse(), reference.GetEndVerse());

                if (selectedVerses != null && selectedVerses.Any())
                {
                    // Combine the text of selected verses
                    string combinedText = string.Join("\n", selectedVerses.Select(v => v.Text));
                    return combinedText;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                throw new Exception($"Failed to retrieve scripture text. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public class ChapterResponse
    {
        public Chapter Chapter { get; set; }
    }

    public class Chapter
    {
        public Verse[] Verses { get; set; }
    }

    public class Verse
    {        
        public string Text { get; set; }
    }
    
    static Verse[] GetVersesInRange(ChapterResponse chapterResponse, int startIndex, int endIndex)
    {
        if (chapterResponse?.Chapter?.Verses != null && startIndex > 0 && endIndex >= 0 && endIndex <= chapterResponse.Chapter.Verses.Length)
        {
            if (endIndex == 0)
            {
                return new Verse[] { chapterResponse.Chapter.Verses[startIndex-1] };
            }
            else
            {
                return chapterResponse.Chapter.Verses.Skip(startIndex-1).Take(endIndex - startIndex + 1).ToArray();
            }
        }
        return null;
    }
    
}