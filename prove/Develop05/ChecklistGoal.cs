/*
Eternal Quest Program - ChecklistGoal [Child of Goal] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _goalTarget;
    private int _goalBonus;

    // Constructor for getting new goal
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _goalTarget = target;
        _goalBonus = bonus;
        _amountCompleted = 0;
    }

    // Overloaded constructor for loading from a file
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _goalTarget = target;
        _goalBonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        // Check if user has already completed it
        if (IsComplete())
        {
            Console.WriteLine("You have already finished this goal!");
            return 0;
        }

        _amountCompleted++;

        if (_amountCompleted == _goalTarget)
        {
            return _points + _goalBonus;
        }
        else
        {
            return _points;
        }
    }

    public override bool IsComplete()
    {
        // If the amount completed is at least = to the target, it is complete
        return _amountCompleted >= _goalTarget;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Currently Completed: {_amountCompleted}/{_goalTarget}"; // Completion status added to the end
    }

    public override string GetStringRepresentation()
    {
        // Formatted for saving to a text file
        return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_goalBonus}|{_goalTarget}|{_amountCompleted}";
    }
}