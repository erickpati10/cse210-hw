using System;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

       
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");

        // Stretch Challenge
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositiveNumber = positiveNumbers.Count > 0 ? positiveNumbers.Min() : 0;

        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}





