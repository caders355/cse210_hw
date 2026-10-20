using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        if (grade >= 90)
        {
            Console.WriteLine("That grade is an A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("That grade is a B");            
        }
        else if (grade >= 70)
        {
            Console.WriteLine("That grade is a C");            
        }        
        else if (grade >= 60)
        {
            Console.WriteLine("That grade is a D");            
        }        
        else
        {
            Console.WriteLine("That grade is an F");            
        }        
        
    }
}