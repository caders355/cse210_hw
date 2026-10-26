/*
Eternal Quest Program - EternalGoal [Child of Goal] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    // Constructor for creating new Eternal Goal
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    // Overloaded constructor for loading existing Eternal Goal from a text file
    public EternalGoal(string name, string description, int points, int timesCompleted) : base(name, description, points)
    {
        _timesCompleted = timesCompleted; // Loads the saved count
    }

    public override int RecordEvent()
    {
        _timesCompleted++; // Add 1 to counter for times completed
        return _points; // Return points every time it is completed
    }

    public override bool IsComplete()
    {
        // Never truly finished, always return false
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) - Completed {_timesCompleted} times";
    }

    public override string GetStringRepresentation()
    {
        // Formatted for saving to a text file
        return $"EternalGoal:{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }
}