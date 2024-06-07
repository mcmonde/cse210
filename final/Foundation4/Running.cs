namespace Foundation4;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / DurationMinutes * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / _distance;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {_distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}