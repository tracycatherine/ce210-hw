public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void Complete()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Congratulations! You have completed: {Name}");
        }
    }

    public override int GetPoints()
    {
        return IsCompleted ? Points : 0;
    }
}