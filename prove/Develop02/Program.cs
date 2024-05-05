using System;

// To exceed expectations: 
// Make my User Interface more interactive by using keypress. You can select via arrow key up and down.
// Added an abstract Menu for creating dynamic Menus in the future interactively.
// Make a csv parser so that it can be opened in a spreadsheet via *.csv format.

class Program 
{
    static void Main(string[] args) 
    {
        string[] choices = { "Write", "Display", "Load", "Save", "Quit" };
        MainMenu mainMenu = new MainMenu(choices);
        
        bool quit = false;

        while (!quit) {
            Console.Clear();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices: (use arrow up and down)");
            mainMenu.DisplayMenu();
            
            ConsoleKeyInfo key = Console.ReadKey(true);
            quit = mainMenu.ProcessKeyPress(key);
        }

        Console.WriteLine("Exiting Journal Program.");
    }
}
