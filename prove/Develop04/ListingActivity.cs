/*
Mindfulness Program - ListingActivity [Child of Activity] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
    {
        _activity = "Listing Activity";
        _instructionText = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _random = new Random();
        _count = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($" ~~ {GetRandomPrompt()} ~~ ");
        Console.Write("You may begin shortly... ");
        ProgressBar(10);
        Console.WriteLine();

        GetListFromUser();

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // private void GetListFromUser()
    // {
    //     List<string> responses = new List<string>();
    //     DateTime startTime = DateTime.Now;
    //     DateTime futureTime = startTime.AddSeconds(_duration);

    //     Console.Write("> ");
    //     string currentInput = "";

    //     while (DateTime.Now < futureTime)
    //     {
    //         if (Console.KeyAvailable)
    //         {
    //             ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                
    //             if (key.Key == ConsoleKey.Enter)
    //             {
    //                 if (!string.IsNullOrWhiteSpace(currentInput))
    //                 {
    //                     responses.Add(currentInput);
    //                 }
    //                 currentInput = "";
    //                 Console.WriteLine();
    //                 Console.Write("< ");
    //             }
    //             else if (key.Key == ConsoleKey.Backspace)
    //             {
    //                 if (currentInput.Length > 0)
    //                 {
    //                     currentInput += key.KeyChar;
    //                     Console.Write(key.KeyChar);
    //                 }
    //             }
    //         }

    //         if (!string.IsNullOrWhiteSpace(currentInput))
    //         {
    //             responses.Add(currentInput);
    //         }

    //         Console.WriteLine();
    //         _count = responses.Count;
    //     }
    // }
    private void GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");

            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                responses.Add(input);
            }
        }
        _count = responses.Count;
    }
}