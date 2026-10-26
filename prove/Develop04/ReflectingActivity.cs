/*
Mindfulness Program - ReflectingActivity [Child of Activity] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;
    private Random _random;

    public ReflectingActivity()
    {
        _activity = "Reflection Activity";
        _instructionText = "This activity will help you refect on times in your life when you have shown strength and resilience. \nThis will help you recognize the power and control you have over your life, and how to use it in other aspects of daily living.";
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndMessage();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);

        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" ~~ {GetRandomPrompt()} ~~ \n");
        Console.WriteLine("When you have something in mind, press Enter to continue. ");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they appear, as relating to this experience: ");
        Console.Write("You may begin shortly...");
        LoadingSpinner(10);
        Console.Clear();
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write($"~> {GetRandomQuestion()} ");
            ProgressBar(10);
            Console.WriteLine();
        }
    }
}