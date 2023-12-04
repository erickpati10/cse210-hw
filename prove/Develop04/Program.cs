using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Select a choice from the menu:");


            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunBreathingActivity();
                    break;
                case "2":
                    RunReflectionActivity();
                    break;
                case "3":
                    RunListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thanks for doing these activities!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void RunBreathingActivity()
    {
        int duration = CommonStartingMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. ");

        Console.WriteLine("Prepare to begin...");
        CountdownTimer(3); 

        int cycleTime = 6; 
        int userInputDuration = duration;
        int completedDuration = 0; 

        while (duration >= cycleTime)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3); 
            CountdownTimer(3); 
            Console.WriteLine("Breathe out...");
            ShowSpinner(3); 
            CountdownTimer(3); 
            duration -= cycleTime; 
            completedDuration += cycleTime; 
        }

        int remainingDuration = userInputDuration;
        DisplayCompletionMessage("Breathing Activity", remainingDuration); 

        ReturnToMenu();
    }

    static void RunReflectionActivity()
    {
        int duration = CommonStartingMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.");

        string[] prompts =
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
           
        };

        Random random = new Random();

        while (duration > 0)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            ShowSpinner(3); 

            string[] reflectionQuestions =
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                
            };

            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                ShowSpinner(5); 
                duration -= 5; 
            }
        }

        DisplayCompletionMessage("Reflection Activity", duration);

        ReturnToMenu();
    }

    static void RunListingActivity()
    {
        int duration = CommonStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string[] prompts =
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            
        };

        Random random = new Random();

        foreach (string prompt in prompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(9000); 

            Console.WriteLine("You have 5 seconds to list items:");
            int remainingTime = duration;

            while (remainingTime > 0)
            {
                string userInput = Console.ReadLine();
                remainingTime -= userInput.Length; 

              
                if (remainingTime < 0)
                {
                    Console.WriteLine("Time's up!");
                    break;
                }

               
            }
        }

        DisplayCompletionMessage("Listing Activity", duration);

        ReturnToMenu();
    }

    static void ShowSpinner(int durationInSeconds)
    {
        for (int i = 0; i < durationInSeconds * 10; i++)
        {
            switch (i % 4)
            {
                case 0:
                    Console.Write("/");
                    break;
                case 1:
                    Console.Write("-");
                    break;
                case 2:
                    Console.Write("\\");
                    break;
                case 3:
                    Console.Write("|");
                    break;
            }
            Thread.Sleep(100); 
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.WriteLine();
    }

    static void CountdownTimer(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Time remaining: {i} seconds");
            Thread.Sleep(1000);
        }
    }

    static int CommonStartingMessage(string activityName, string description)
    {
        Console.WriteLine($"Activity: {activityName}");
        Console.WriteLine(description);
        Console.Write("Enter the duration of the activity in seconds: ");
        return int.Parse(Console.ReadLine());
    }

    static void DisplayCompletionMessage(string activityName, int completedDuration)
    {
        Console.WriteLine($"You have completed the {activityName} for {completedDuration} seconds.");
        Thread.Sleep(3000); 
    }

    static void ReturnToMenu()
    {
        Console.WriteLine("Returning to the main menu...");
        Thread.Sleep(2000); 
        Console.WriteLine();
    }
}
