using System;
using System.Collections.Generic;
using System.IO;

public class PromptGenerator 
{
    private List<string> _prompts = new List<string>();

    public PromptGenerator() 
    {
        LoadPromptsFromFile("prompts.csv");
    }

    public void AddPrompt(string prompt) 
    {
        _prompts.Add(prompt);
    }

    public string GetRandomPrompt() 
    {
        if (_prompts.Count > 0) {
            Random rnd = new Random();
            int index = rnd.Next(_prompts.Count);
            return _prompts[index];
        } else {
            Console.WriteLine("No prompts available. Please add prompts before getting a random prompt.");
            return null; 
        }
    }
    
    public void SavePromptsToFile(string file) 
    {
        if (!file.EndsWith(".csv")) {
            Console.WriteLine("Error: File must be a *.csv extension.");
            return;
        }
        using (StreamWriter writer = new StreamWriter(file)) {
            foreach (var prompt in _prompts) {
                writer.WriteLine($"\"{prompt}\"");
            }
        }
        Console.WriteLine("New prompt saved to filename 'prompts.csv'.");
    }

    private void LoadPromptsFromFile(string file) 
    {
        if (!file.EndsWith(".csv")) {
            Console.WriteLine("Error: File must be a *.csv extension.");
            return;
        }
        if (File.Exists(file) && new FileInfo(file).Length > 0) {
            _prompts.Clear();
            using (StreamReader reader = new StreamReader(file)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    // Remove quotes if present
                    string prompt = RemoveQuotes(line.Trim());
                    _prompts.Add(prompt);
                }
            }
            Console.WriteLine("File loaded successfully.");
        } else {
            Console.WriteLine($"File '{file}' does not exist or is empty. Loading default prompts.");
            // Default prompts
            _prompts.Add("Who was the most interesting person I interacted with today?");
            _prompts.Add("What was the best part of my day?");
            _prompts.Add("How did I see the hand of the Lord in my life today?");
            _prompts.Add("What was the strongest emotion I felt today?");
            _prompts.Add("If I had one thing I could do over today, what would it be?");

            this.SavePromptsToFile("prompts.csv");
        }
    }

    private string RemoveQuotes(string text) {
        // Remove quotes if present
        if (text.StartsWith("\"") && text.EndsWith("\"")) {
            return text.Substring(1, text.Length - 2);
        }
        return text;
    }

}