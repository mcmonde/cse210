using System;

public class Journal 
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry) 
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll() 
    {
        foreach (var entry in _entries) {
            entry.Display();
        }
    }

    public void SaveToFile(string file) 
    {
        if (!file.EndsWith(".csv")) {
            Console.WriteLine("Error: File must be a *.csv extension.");
            return;
        }
        using (StreamWriter writer = new StreamWriter(file)) {
            foreach (var entry in _entries) {
                writer.WriteLine($"\"{entry.Date}\", \"{entry.PromptText}\", \"{entry.EntryText}\"");
            }
        }
    }

    public void LoadFromFile(string file) 
    {
        if (!file.EndsWith(".csv")) {
            Console.WriteLine("Error: File must be a *.csv extension.");
            return;
        }
        if (File.Exists(file)) {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(file)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = SplitCsvLine(line);

                    if (parts.Length == 3) {
                        // Remove quotes if present in fields
                        string date = RemoveQuotes(parts[0].Trim());
                        string promptText = RemoveQuotes(parts[1].Trim());
                        string entryText = RemoveQuotes(parts[2].Trim());

                        _entries.Add(new Entry(date, promptText, entryText));
                    }
                }
            }
            Console.WriteLine("File loaded successfully.");
        } else {
            Console.WriteLine($"File '{file}' does not exist.");
        }
    }

    private string RemoveQuotes(string text) 
    {
        // Remove quotes if present
        if (text.StartsWith("\"") && text.EndsWith("\"")) {
            return text.Substring(1, text.Length - 2);
        }
        return text;
    }

    private string[] SplitCsvLine(string line) {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        int start = 0;

        for (int i = 0; i < line.Length; i++) {
            if (line[i] == '"') {
                inQuotes = !inQuotes;
            } else if (line[i] == ',' && !inQuotes) {
                parts.Add(line.Substring(start, i - start));
                start = i + 1;
            }
        }

        parts.Add(line.Substring(start));
        return parts.ToArray();
    }
}