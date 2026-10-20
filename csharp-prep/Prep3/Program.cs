using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
        
            if (guess > magicNumber)
            {
                Console.WriteLine("Guess lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Guess higher");
            }
            else if (guess == magicNumber)
            {
                Console.WriteLine($"Congrats, you guessed it! The number was {magicNumber}");                
            }
        }
    }
}