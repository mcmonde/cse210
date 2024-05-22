using System;
using Develop04;

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
                    case "Start breathing activity":
                        string name = "Welcome to the Breathing Activity";
                        string description = "This activity will help you relax by walking through breathing in " +
                                             "and out slowly. Clear your mind and focus on your breathing.";
                        BreathingActivity breath = new BreathingActivity(name, description);
                        Console.Clear();
                        breath.DisplayStartingMessage();
                        breath.DisplayEndingMessage();
                        breath.Run();
                        break;
                    case "Start reflecting activity":
                        break;
                    case "Start listing activity":
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