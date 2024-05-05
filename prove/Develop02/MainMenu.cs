using System;

class MainMenu : Menu
{
    private Journal _journal = new Journal();
    private PromptGenerator _promptGenerator = new PromptGenerator();
    
    public MainMenu(string[] choices) : base(choices) { }
    
    public override bool ProcessKeyPress(ConsoleKeyInfo key) 
    {
        switch (key.Key) {
            case ConsoleKey.UpArrow:
                ChoiceIndex = Math.Max(0, ChoiceIndex - 1);
                return false;
            case ConsoleKey.DownArrow:
                ChoiceIndex = Math.Min(Choices.Length - 1, ChoiceIndex + 1);
                return false;
            case ConsoleKey.Enter:
                string choice = Choices[ChoiceIndex];
                switch (choice) {
                    case "Write":
                        WriteEntry(_journal, _promptGenerator);
                        break;
                    case "Display":
                        _journal.DisplayAll();
                        break;
                    case "Load":
                        Console.WriteLine("Enter the filename here: ");
                        string loadFile = Console.ReadLine();
                        _journal.LoadFromFile(loadFile);
                        break;
                    case "Save":
                        Console.WriteLine("Enter the filename here: ");
                        string saveFile = Console.ReadLine();
                        _journal.SaveToFile(saveFile);
                        break;
                    case "Quit":
                        Console.WriteLine("Exiting Journal Program.");
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                return choice == "Quit";
            default:
                return false;
        }
    }
    
    private void WriteEntry(Journal journal, PromptGenerator promptGenerator) 
    {
        DateTime currentDate = DateTime.Now;
        string date = currentDate.ToString("yyyy-MM-dd H:m:s");
        Console.WriteLine($"<Journal Entry {date}>");
        
        string promptText = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"{promptText}");

        Console.Write("> ");
        string entryText = Console.ReadLine();

        Entry newEntry = new Entry(date, promptText, entryText);
        journal.AddEntry(newEntry);
    }
}