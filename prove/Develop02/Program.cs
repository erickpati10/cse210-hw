using System;
using System.Collections.Generic;



class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string randomPrompt = "";

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

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
                    randomPrompt = DisplayRandomPrompt();
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    myJournal.AddEntry(randomPrompt, response);
                    break;
                case 2:
                    myJournal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveFileName = Console.ReadLine();
                    myJournal.SaveToFile(saveFileName);
                    break;
                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadFileName = Console.ReadLine();
                    myJournal.LoadFromFile(loadFileName);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response)
    {
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Entry newEntry = new Entry(prompt, response, currentDate);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        // Logic to save entries to the specified file
        // Implementation not included in this example
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        // Logic to load entries from the specified file
        // Implementation not included in this example
        Console.WriteLine($"Journal loaded from {filename}");
    }
}

    static Random rnd = new Random();
    static string DisplayRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        int index = rnd.Next(prompts.Length);
        string randomPrompt = prompts[index];
        Console.WriteLine($"Prompt: {randomPrompt}");
        return randomPrompt;
    }
}
