public class EternalGoal : Goal
{
    private int TimesCompleted { get; set; }

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        TimesCompleted = 0;
    }

    public override void Complete()
    {
        TimesCompleted++;
        Console.WriteLine($"You recorded progress for: {Name}");
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name}: {Description} (Points: {Points} each time) - Completed {TimesCompleted} times");
    }

    public override int GetPoints()
    {
        return Points * TimesCompleted;
    }
}