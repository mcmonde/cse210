using System;

class Program
{
    static void Main(string[] args)
    {
        string[] choices = { "Start breathing activity", "Start reflecting activity", "Start listing activity", "Quit" };
        MainMenu mainMenu = new MainMenu(choices);

        bool quit = false;

        while (!quit) {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program.");
            Console.WriteLine("Please select one of the following options: (use arrow up and down)");
            mainMenu.DisplayMenu();
            
            ConsoleKeyInfo key = Console.ReadKey(true);
            quit = mainMenu.ProcessKeyPress(key);
        }
        
        Console.WriteLine("Exiting Journal Program.");
    }
}