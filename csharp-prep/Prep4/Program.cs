using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.WriteLine("(Type 0 to quit)");
            Console.WriteLine("Enter a number: ");

            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        double listAverage = numbers.Average();
        int listMax = numbers.Max();

        //numbers.ForEach(Console.WriteLine);
        Console.WriteLine($"The Sum of the numbers is: {numbers.Count}");
        Console.WriteLine($"The Average of the numbers is: {listAverage:N2}");
        Console.WriteLine($"The Largest number is: {listMax}");
    }
}