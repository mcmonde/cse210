namespace Foundation4;

public class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        DurationMinutes = durationMinutes; // Using the property setter
    }

    public int DurationMinutes
    {
        get { return _durationMinutes; }
        set { _durationMinutes = value; }
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} - {GetType().Name} ({DurationMinutes} min)";
    }
}