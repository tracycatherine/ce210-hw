
public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int Progress { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints) 
        : base(name, description, points)
    {
        Target = target;
        Progress = 0;
        BonusPoints = bonusPoints;
    }

    public override void Complete()
    {
        Progress++;
        if (Progress >= Target && !IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Congratulations! You have completed {Name} and earned a bonus!");
        }
        else
        {
            Console.WriteLine($"Progress: {Progress}/{Target}");
        }
    }

    public override void DisplayGoal()
    {
        string checkbox = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{checkbox} {Name}: {Description} -- Currently completed: {Progress}/{Target}");
    }

    public override int GetPoints()
    {
        int basePoints = Points * Progress;
        return IsCompleted ? basePoints + BonusPoints : basePoints;
    }
}