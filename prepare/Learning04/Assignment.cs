using System;

public class Assignment
{
    private string studentName;
    private string topic;

    public Assignment(string name, string assignedTopic)
    {
        studentName = name;
        topic = assignedTopic;
    }

    public string GetSummary()
    {
        return $"{studentName} - {topic}";
    }
}
