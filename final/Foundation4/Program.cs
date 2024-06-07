using System;
using System.Collections.Generic;

public class Activity
{
    private DateTime date;
    private int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
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
        return $"{date.ToString("dd MMM yyyy")} - {GetType().Name} ({durationMinutes} min)";
    }
}

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / durationMinutes * 60;
    }

    public override double GetPace()
    {
        return durationMinutes / distance;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Speed: {speed} kph, Pace: {GetPace()} min per km";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / durationMinutes * 60;
    }

    public override double GetPace()
    {
        return durationMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 4.8));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 30, 9.7));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 20));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
