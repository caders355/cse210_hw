/*
Mindfulness Program - Activity [Parent of BreathingActivity, ReflectingActivity, ListingActivity] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Threading;

public class Activity
{
    protected string _activity;
    protected string _instructionText;
    protected int _duration;

    public Activity()
    {
        _activity = "General Activity";
        _instructionText = "General Mindfulness Activity";
        _duration = 0;
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activity}.\n");
        Console.WriteLine($"{_instructionText}");
        Console.Write($"How long, in seconds, would you like to do this {_activity} for? ");

        string durationInput = Console.ReadLine();
        _duration = int.Parse(durationInput);

        Console.Clear();
        Console.WriteLine("Get ready...");
        LoadingSpinner(10);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        LoadingSpinner(5);
        Console.WriteLine($"\nYou have completed a {_activity} for {_duration} seconds.");
        LoadingSpinner(10);
    }

    public void LoadingSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\"};
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ProgressBar(int seconds)
    {
        int barLength = 20;

        int delay = (seconds * 1000) / barLength;

        for (int i = 0; i <= barLength; i++)
        {
            string filled = new string('#', i);
            string empty = new string('-', barLength - i);
            string progressBar = $"[{filled}{empty}]";

            Console.Write(progressBar);

            Thread.Sleep(delay);

            if (i < barLength)
            {
                string backspaces = new string('\b', progressBar.Length);
                Console.Write(backspaces);
            }
        }
    }
    // public void LoadingAnimation(int seconds)
    // {
    //     for (int i = seconds; i > 0; i--)
    //     {
    //         Console.Write(i);
    //         Thread.Sleep(1000);

    //         string blankSpace = new string(' ', i.ToString().Length);
    //         string backspaces = new string('\b', i.ToString().Length);

    //         Console.Write($"{backspaces}{blankSpace}{backspaces}");
    //     }
    // }
}