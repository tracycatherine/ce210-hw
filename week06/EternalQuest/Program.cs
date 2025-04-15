using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {totalScore} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;
        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goals.Add(newGoal);
    }

    private static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].DisplayGoal();
        }
    }

    private static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        
        if (index >= 0 && index < goals.Count)
        {
            goals[index].Complete();
            int pointsEarned = goals[index].GetPoints();
            totalScore += pointsEarned;
            Console.WriteLine($"You now have {totalScore} points!");
        }
    }

    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalScore);
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsCompleted}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.Progress}|{checklistGoal.Target}|{checklistGoal.BonusPoints}");
                }
            }
        }
    }

    private static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            totalScore = int.Parse(lines[0]);
            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                    case "EternalGoal":
                        goals.Add(CreateGoalFromParts(parts));
                        break;
                    case "ChecklistGoal":
                        string[] extraParts = lines[++i].Split('|');
                        goals.Add(CreateChecklistGoalFromParts(parts, extraParts));
                        break;
                }
            }
        }
    }

    private static Goal CreateGoalFromParts(string[] parts)
    {
        if (parts[0] == "SimpleGoal")
            return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
        else
            return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }

    private static Goal CreateChecklistGoalFromParts(string[] parts, string[] extraParts)
    {
        var goal = new ChecklistGoal(
            parts[1], 
            parts[2], 
            int.Parse(parts[3]), 
            int.Parse(extraParts[1]), 
            int.Parse(extraParts[2])
        );
        goal.Progress = int.Parse(extraParts[0]);
        return goal;
    }
}