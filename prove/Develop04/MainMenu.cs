using System;

class MainMenu : Menu
{

    public MainMenu(string[] choices) : base(choices)
    {
    }

    public override bool ProcessKeyPress(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                ChoiceIndex = Math.Max(0, ChoiceIndex - 1);
                return false;
            case ConsoleKey.DownArrow:
                ChoiceIndex = Math.Min(Choices.Length - 1, ChoiceIndex + 1);
                return false;
            case ConsoleKey.Enter:
                string choice = Choices[ChoiceIndex];
                switch (choice)
                {
                    case "Breathing":
                        break;
                    case "Reflecting":
                        break;
                    case "Listening":
                        break;
                    case "Quit":
                        Console.WriteLine("Exiting Program.");
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
}