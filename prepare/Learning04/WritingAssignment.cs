using System;

public class WritingAssignment : Assignment
{
    private string bookTitle;

    public WritingAssignment(string name, string assignedTopic, string bookTitle)
        : base(name, assignedTopic)
    {
        this.bookTitle = bookTitle;
    }

    public string GetWritingInformation()
    {
        return $"{GetSummary()}\n{bookTitle} by {GetStudentName()}";
    }

    public string GetStudentName()
    {
        return base.GetSummary().Split(" - ")[0];
    }
}
