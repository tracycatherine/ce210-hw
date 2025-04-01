using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create video objects
        Video video1 = new Video("C# Programming Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Thanks for the clear explanation."));
        video1.AddComment(new Comment("Charlie", "Looking forward to more content."));

        Video video2 = new Video("Learn C# in 30 Days", "Jane Smith", 1200);
        video2.AddComment(new Comment("David", "This is really helpful!"));
        video2.AddComment(new Comment("Eva", "I love how concise this tutorial is."));
        video2.AddComment(new Comment("Frank", "I had a problem with Step 5, but the rest was perfect!"));

        Video video3 = new Video("Advanced C# Concepts", "Tom Brown", 1500);
        video3.AddComment(new Comment("Grace", "Very detailed, thank you!"));
        video3.AddComment(new Comment("Hank", "Excellent explanation of complex topics."));
        video3.AddComment(new Comment("Ivy", "You should add more examples of LINQ."));

        // Store all video objects in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through videos and display information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo(); // Display video information and comments
        }
    }
}