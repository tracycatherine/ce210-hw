
public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }  // Added to track completion

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public virtual void DisplayGoal()
    {
        string checkbox = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{checkbox} {Name}: {Description} (Points: {Points})");
    }

    public abstract void Complete();
    public abstract int GetPoints();
}