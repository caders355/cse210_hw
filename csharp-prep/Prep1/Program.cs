using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?");
        string First_Name = Console.ReadLine();
        Console.Write("What is your last name?");
        string Last_Name = Console.ReadLine();
        Console.WriteLine($"Your name is {Last_Name}, {First_Name} {Last_Name}.");
    }
}