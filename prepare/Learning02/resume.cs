using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs;

    public Resume()
    {
        _jobs = new List<Job>();
    }

    public void Display()
    {
        Console.WriteLine($"Resume of {_name}:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}

   