namespace Develop05;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void Start()
    {
        // Load goals and score from file or initialize as needed
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nCurrent points: {_score} \n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nList of Goals: ");
        int i = 1;
        foreach (var goal in _goals) {
            string checkbox = goal.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i++}. {checkbox} {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        var goal = _goals.Find(g => g.ShortName == goalName);
        
        if (goal != null) {
            goal.RecordEvent();
            _score += goal.Points;
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete()) {
                _score += checklistGoal.GetBonus();
            }
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score); // Save the score first
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename)) {
            using (StreamReader reader = new StreamReader(filename)) {
                string line = reader.ReadLine();
                if (int.TryParse(line, out int score)) {
                    _score = score;
                }
                
                _goals.Clear();

                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    switch (parts[0])
                    {
                        case "SimpleGoal":
                            var simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                            if (bool.Parse(parts[4]))
                                simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "ChecklistGoal":
                            var checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                            for (int i = 0; i < int.Parse(parts[6]); i++)
                                checklistGoal.RecordEvent();
                            _goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }
    }
}
