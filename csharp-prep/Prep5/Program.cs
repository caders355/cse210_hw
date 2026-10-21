using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number? ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    static int PromptUserBirthYear()
    {
        Console.WriteLine("What is your birth year? ");
        int birthYear = int.Parse(Console.ReadLine());
        return birthYear;
    }

    static int SquareNumber(ref int userNumber)
    {
        int birthYear = userNumber * userNumber;
        return birthYear;
    }

    static void DisplayResult(string userName, int squareNum, int birthYear)
    {
        Console.WriteLine($"{userName}, the square of your favorite number is {squareNum}. \n{userName}, you will turn {2026 - birthYear} years old this year(2026). ");

    }

    static void Main(string[] args)
    {
        DisplayWelcome();


        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int birthYear = PromptUserBirthYear();
        int squareNum = SquareNumber(ref userNumber);
        
        DisplayResult(userName, squareNum, birthYear);
    }
}