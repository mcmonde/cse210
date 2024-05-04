using System;

public class Journal 
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry) {
        _entries.Add(newEntry);
    }

    public void DisplayAll() {
        foreach (var entry in _entries) {
            entry.Display();
        }
    }

    public void SaveToFile(string file) {
        using (StreamWriter writer = new StreamWriter(file)) {
            foreach (var entry in _entries) {
                writer.WriteLine($"{entry.Date}, {entry.PromptText}, {entry.EntryText}");
            }
        }
    }

    public void LoadFromFile(string file) {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split(',');
                if (parts.Length == 3) {
                    Entry entry = new Entry(parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
                    _entries.Add(entry);
                }
            }
        }
    }
}