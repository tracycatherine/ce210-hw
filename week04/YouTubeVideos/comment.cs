using System;

public class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
        Timestamp = DateTime.Now;  // Automatically set timestamp to current time
    }

    // Method to return a formatted comment including the timestamp
    public string GetFormattedComment()
    {
        return $"{Commenter} ({Timestamp:MM/dd/yyyy HH:mm}): {Text}";
    }
}