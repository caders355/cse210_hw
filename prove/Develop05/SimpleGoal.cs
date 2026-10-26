/*
Eternal Quest Program - SimpleGoal [Child of Goal] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor for creating a new goal
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Overloaded constructor for loading from a file
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        else
        {
            Console.WriteLine("You have already completed this goal.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Formatted for saving to a text file
        return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}