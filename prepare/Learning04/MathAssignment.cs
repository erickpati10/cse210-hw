using System;

public class MathAssignment : Assignment
{
    private string section;
    private string problemsRange;

    public MathAssignment(string name, string assignedTopic, string section, string problemsRange)
        : base(name, assignedTopic)
    {
        this.section = section;
        this.problemsRange = problemsRange;
    }

    public string GetHomeworkList()
    {
        return $"{GetSummary()}\n{section} Problems {problemsRange}";
    }
}
