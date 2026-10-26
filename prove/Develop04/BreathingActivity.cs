/*
Mindfulness Program - BreathingActivity [Child of Activity] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _activity = "Breathing Activity";
        _instructionText = "This activity will help you relax by guiding you through breathing in and out, slowly. Try to clear your mind, and focus on your breathing";
    }

    public void Run()
    {
        DisplayStartMessage();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...        ");
            ProgressBar(3);
            Console.WriteLine();

            Console.Write("Now breathe out...   ");
            ProgressBar(5);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}