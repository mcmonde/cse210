namespace Develop05;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string completionStatus = _isComplete ? "Yes" : "No";
        return $"{ShortName}: {Description} - {Points} points. Complete: {completionStatus}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}
