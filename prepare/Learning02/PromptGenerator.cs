using System;

public class PromptGenerator {
    private List<string> _prompts = new List<string>();

    public void AddPrompt(string prompt) {
        _prompts.Add(prompt);
    }

    public string GetRandomPrompt() {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}