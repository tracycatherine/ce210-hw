using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2025, 2, 18), 30, 4.8),
            new Cycling(new DateTime(2025, 2, 18), 30, 9.7),
            new Swimming(new DateTime(2025, 2, 18), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}