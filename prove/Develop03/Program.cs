using System;
using System.Text.RegularExpressions;

// To exceed expectations:
// Added an api that gets the scripture reference.
// Should have an internet connection to fetch the scripture verses.
// Add a parser for scripture input.

class Program
{
    static async Task Main(string[] args)
    {
        bool tryAgain = true;
        while (tryAgain)
        {
            Console.Clear();

            Console.Write("Enter the scripture reference (e.g., 2 Nephi 2:25-26): ");
            string scriptureReference = Console.ReadLine();

            var reference = ParseScriptureReference(scriptureReference);
            
            if (reference != null)
            {
                string scriptureText = $"{await GetScriptureTextAsync(reference)}";

                Scripture scripture = new Scripture(reference, scriptureText);
                Random random = new Random();

                while (!scripture.IsCompletelyHidden())
                {
                    Console.Clear();

                    Console.WriteLine(scripture.GetDisplayText());

                    Console.WriteLine("\nPress Enter to hide more words or type 'quit' to end: ");
                    string userInput = Console.ReadLine();
                    if (userInput.ToLower() == "quit")
                    {
                        break;
                    }

                    scripture.HideRandomWords(random.Next(1, 4));
                }

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("All words in the scripture are hidden.");
                }
            }
            else
            {
                Console.WriteLine("Invalid scripture reference format. Please try again.");
            }

            Console.WriteLine("Do you want to try again? (yes/no)");
            string tryAgainInput = Console.ReadLine().ToLower();
            tryAgain = tryAgainInput == "yes";
        }
    }
    
    static Reference ParseScriptureReference(string reference)
    {
        Regex regex = new Regex(@"^(?:(?<num>\d+)\s)?(?<book>(?:\d+\s)?(?:\w+\s)+\w+)\s(?<chapter>\d+):(?<startVerse>\d+)(?:-(?<endVerse>\d+))?$");

        Match match = regex.Match(reference);

        if (match.Success)
        {
            string book = match.Groups["num"].Success ? match.Groups["num"].Value + " " + match.Groups["book"].Value.Trim() : match.Groups["book"].Value.Trim();
            int chapter = int.Parse(match.Groups["chapter"].Value);
            int startVerse = int.Parse(match.Groups["startVerse"].Value);
            int endVerse = match.Groups["endVerse"].Success ? int.Parse(match.Groups["endVerse"].Value) : startVerse;

            return new Reference(book, chapter, startVerse, endVerse);
        }

        return null;
    }

    
    static async Task<string> GetScriptureTextAsync(Reference reference)
    {
        try
        {
            ScriptureApiClient apiClient = new ScriptureApiClient();
            return await apiClient.GetScriptureTextAsync(reference);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching scripture text: {ex.Message}");
            return null;
        }
    }
}
