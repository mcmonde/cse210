namespace Develop05;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never complete, they just accumulate points
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals never complete
    }

    public override string GetDetailsString()
    {
        return $"{ShortName}: {Description} - {Points} points. Eternal goal.";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{ShortName}|{Description}|{Points}";
    }
}
