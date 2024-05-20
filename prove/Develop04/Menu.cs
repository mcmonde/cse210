using System;

abstract class Menu 
{
    protected string[] Choices;
    protected int ChoiceIndex;

    public Menu(string[] choices) 
    {
        Choices = choices;
        ChoiceIndex = 0;
    }

    public void DisplayMenu() 
    {
        for (int i = 0; i < Choices.Length; i++) {
            if (i == ChoiceIndex) {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("=> ");
            } else {
                Console.Write("   ");
            }

            Console.WriteLine($"{i + 1}. {Choices[i]}");

            if (i == ChoiceIndex) {
                Console.ResetColor();
            }
        }
    }

    public abstract bool ProcessKeyPress(ConsoleKeyInfo key);
}