using System;
using System.Collections.Generic;
using System.IO;

class Goal
{
    protected string name;
    protected int points;
    protected bool completed;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        this.completed = false;
    }

    public virtual void MarkComplete()
    {
        completed = true;
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public int GetPoints()
    {
        return points;
    }

    public string GetName()
    {
        return name;
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void MarkComplete()
    {
        // Eternal goals never truly complete
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
        this.bonusPoints = bonusPoints;
    }

    public override void MarkComplete()
    {
        currentCount++;
        if (currentCount >= targetCount)
        {
            completed = true;
        }
    }

    public new int GetPoints()
    {
        if (completed)
        {
            return points + bonusPoints;
        }
        else
        {
            return points;
        }
    }
}

class GoalTracker
{
    private List<Goal> goals;
    private int score;

    public GoalTracker()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void CreateSimpleGoal(string name, int points)
    {
        goals.Add(new SimpleGoal(name, points));
    }

    public void CreateEternalGoal(string name, int points)
    {
        goals.Add(new EternalGoal(name, points));
    }

    public void CreateChecklistGoal(string name, int points, int targetCount, int bonusPoints)
    {
        goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
    }

    public void RecordEvent(string goalName)
    {
        foreach (Goal goal in goals)
        {
            if (goal.GetName() == goalName)
            {
                goal.MarkComplete();
                score += goal.GetPoints();
            }
        }
    }

    public void ListGoals()
    {
        foreach (Goal goal in goals)
        {
            if (goal is ChecklistGoal)
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                if (checklistGoal.IsCompleted())
                {
                    Console.WriteLine($"[X] {goal.GetName()} - Completed {checklistGoal.GetPoints()} points");
                }
                else
                {
                    Console.WriteLine($"[ ] {goal.GetName()} - Completed {checklistGoal.GetPoints()} points");
                }
            }
            else
            {
                if (goal.IsCompleted())
                {
                    Console.WriteLine($"[X] {goal.GetName()}");
                }
                else
                {
                    Console.WriteLine($"[ ] {goal.GetName()}");
                }
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetName()},{goal.GetPoints()},{goal.IsCompleted()}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] goalInfo = line.Split(',');
                string name = goalInfo[0];
                int points = int.Parse(goalInfo[1]);
                bool completed = bool.Parse(goalInfo[2]);

                if (completed)
                {
                    score += points;
                }

                if (name != null)
                {
                    if (!completed)
                    {
                        goals.Add(new EternalGoal(name, points));
                    }
                    else
                    {
                        goals.Add(new SimpleGoal(name, points));
                    }
                }
            }
        }
    }
}




class Program
{
    static void Main(string[] args)
    {
        GoalTracker tracker = new GoalTracker();

        Console.WriteLine("Welcome to the Eternal Quest Goal Tracker!");

        while (true)
        {
            Console.WriteLine("\nSelect an action:");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Select the type of goal to create:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");

                    Console.Write("Enter your choice: ");
                    int goalTypeChoice;
                    if (!int.TryParse(Console.ReadLine(), out goalTypeChoice))
                    {
                        Console.WriteLine("Invalid input for goal type. Please enter a number.");
                        break;
                    }

                    Console.Write("Enter the name of the goal: ");
                    string goalName = Console.ReadLine();

                    Console.Write("Enter the points for this goal: ");
                    int goalPoints;
                    if (!int.TryParse(Console.ReadLine(), out goalPoints))
                    {
                        Console.WriteLine("Invalid input for points. Please enter a number.");
                        break;
                    }

                    switch (goalTypeChoice)
                    {
                        case 1:
                            tracker.CreateSimpleGoal(goalName, goalPoints);
                            break;

                        case 2:
                            tracker.CreateEternalGoal(goalName, goalPoints);
                            break;

                        case 3:
                            Console.Write("Enter the target count for this goal: ");
                            int targetCount;
                            if (!int.TryParse(Console.ReadLine(), out targetCount))
                            {
                                Console.WriteLine("Invalid input for target count. Please enter a number.");
                                break;
                            }
                            Console.Write("Enter the bonus points for this goal: ");
                            int bonusPoints;
                            if (!int.TryParse(Console.ReadLine(), out bonusPoints))
                            {
                                Console.WriteLine("Invalid input for bonus points. Please enter a number.");
                                break;
                            }
                            tracker.CreateChecklistGoal(goalName, goalPoints, targetCount, bonusPoints);
                            break;

                        default:
                            Console.WriteLine("Invalid choice for goal type.");
                            break;
                    }
                    Console.WriteLine("Goal created successfully!");
                    break;

                case 2:
                    Console.WriteLine("\nList of Goals:");
                    tracker.ListGoals();
                    break;

                case 3:
                    Console.Write("Enter the name of the event: ");
                    string eventName = Console.ReadLine();
                    tracker.RecordEvent(eventName);
                    Console.WriteLine("Event recorded successfully!");
                    break;

                case 4:
                    tracker.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved successfully!");
                    break;

                case 5:
                    tracker.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded successfully!");
                    break;

                case 6:
                    Console.WriteLine("Exiting program. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
