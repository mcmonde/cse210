// To exceed expectations:
// added error handlings such as don't display in Record Event if event is done already.

namespace Develop05;
using System;

class Program
{
    static GoalManager goalManager = new GoalManager();

    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit) {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Console.Clear();
                    CreateNewGoal();
                    break;
                
                case "2":
                    Console.Clear();
                    goalManager.ListGoalDetails();
                    break;
                
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter the filename to save the goals: ");
                    string savefilename = Console.ReadLine();
                    goalManager.SaveGoals(savefilename);
                    Console.WriteLine("Goals saved successfully.");
                    break;
                
                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter the filename to load the goals:");
                    string loadfilename = Console.ReadLine();
                    goalManager.LoadGoals(loadfilename);
                    Console.WriteLine("Goals loaded successfully.");
                    Console.WriteLine("Goals loaded successfully.");
                    break;
                
                case "5":
                    Console.Clear();
                    
                    List<Goal> incompleteGoals = goalManager.GetGoals().Where(g => !g.IsComplete()).ToList();
                    
                    for (int i = 0; i < incompleteGoals.Count; i++) {
                        Console.WriteLine($"{i + 1}. {incompleteGoals[i].ShortName}");
                    }
                    
                    Console.Write("Choose the goal number you completed: ");
                    
                    if (int.TryParse(Console.ReadLine(), out int choiced) && choiced > 0 && choiced <= incompleteGoals.Count) {
                        var selectedGoal = incompleteGoals[choiced - 1];
                        goalManager.RecordEvent(selectedGoal.ShortName);
                        Console.WriteLine($"Event recorded for goal '{selectedGoal.ShortName}'.");
                        Console.WriteLine($"Points earned: {selectedGoal.Points}");
                    } else {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                    break;
                
                case "6":
                    quit = true;
                    break;
                
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        goalManager.DisplayPlayerInfo();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Enter your choice: ");
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Enter goal type (1: Simple, 2: Eternal, 3: Checklist):");
        string typeChoice = Console.ReadLine();

        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter points for the goal:");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (typeChoice) {
            case "1":
                goalManager.CreateGoal(new SimpleGoal(name, description, points));
                break;
            
            case "2":
                goalManager.CreateGoal(new EternalGoal(name, description, points));
                break;
            
            case "3":
                Console.WriteLine("Enter target count:");
                int target = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonus = Convert.ToInt32(Console.ReadLine());
                goalManager.CreateGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }
}