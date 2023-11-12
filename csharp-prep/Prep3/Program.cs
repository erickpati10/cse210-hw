using System;

class Program
{
    static void Main(string[] args)
     {

        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        // Console.Write("What is your guess? ");
        // int userGuess = int.Parse(Console.ReadLine());

        // if (userGuess < magicNumber)
        // {
        //     Console.WriteLine("Higher");
        // }
        // else if (userGuess > magicNumber)
        // {
        //     Console.WriteLine("Lower");
        // }
        // else
        // {
        //     Console.WriteLine("You guessed it!");
        // }
        
        // Part #3

        Random random = new Random();
        int magicNumber = random.Next(1, 101); 

        int userGuess;

        do
        {
            Console.Write("What is your guess? ");
            userGuess = Convert.ToInt32(Console.ReadLine());

            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (userGuess != magicNumber);
    }
}