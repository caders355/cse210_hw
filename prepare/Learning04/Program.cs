using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Jason Sharp", "European History");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mAssignment1 = new MathAssignment("Jason Sharp", "Functions", "7.3", "8-19");
        Console.WriteLine(mAssignment1.GetSummary());
        Console.WriteLine(mAssignment1.GetHomeWorkList());

        WritingAssignment wAssignment1 = new WritingAssignment("Jason Sharp", "Programming With Classes", "Importance of Encapsulation");
        Console.WriteLine(wAssignment1.GetSummary());
        Console.WriteLine(wAssignment1.GetWritingInformation());
    }
}