/*
Eternal Quest Program - GoalManager Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            UpdateLevel();
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("     1. Create New Goal");
            Console.WriteLine("     2. List Goals");
            Console.WriteLine("     3. Save Goals");
            Console.WriteLine("     4. Load Goals");
            Console.WriteLine("     5. Record Event");
            Console.WriteLine("     6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                running = false;
            }
        }
    }
    private void UpdateLevel()
    {
        // 
        int calculatedLevel = (_score / 100) + 1;

        if (calculatedLevel > _level)
        {
            _level = calculatedLevel;
            Console.WriteLine($"\n*** LEVEL UP! You are now Eternal Quest level {_level}! ***");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nLevel: {_level} | Total Score: {_score}");

        // Points for calculating progress
        int pointsPerLevel = 100;
        int currentLevelPoints = _score % pointsPerLevel; // Points earned toward next level

        // Progress bar settings
        int barLength = 20; // Width of bar, in characters
        double progressPercent = (double)currentLevelPoints / pointsPerLevel;

        // Calculate how many blocks to fill in
        int filledBlocks = (int)Math.Round(progressPercent * barLength);
        int emptyBlocks = barLength - filledBlocks;

        // Build bar strings
        string filledString = new string('■', filledBlocks);
        string emptyString = new string('-', emptyBlocks);

        // Display progress bar
        Console.WriteLine($"Next Level: [{filledString}{emptyString}] {currentLevelPoints}/{pointsPerLevel}");
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("     1. Simple Goal");
        Console.WriteLine("     2. Eternal Goal");
        Console.WriteLine("     3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create?");
        string goalType = Console.ReadLine();

        Console.WriteLine("What is the name of your goal?");
        string goalName = Console.ReadLine();
        Console.WriteLine("What does your goal entail (write a brief description)?");
        string goalDescription = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal?");
        int goalPoints = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(goalName, goalDescription, goalPoints));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(goalName, goalDescription, goalPoints));
        }
        else if (goalType == "3")
        {
            Console.WriteLine("How many times does this goal need to be accomplished for it to be complete?");
            int goalTarget = int.Parse(Console.ReadLine());

            Console.WriteLine($"What is the bonus for accomplishing this goal {goalTarget} times?");
            int goalBonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, goalTarget, goalBonus));
        }
        else
        {
            Console.WriteLine("An error occurred, please try again.");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        UpdateLevel();
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Save the total score on the first line
            outputFile.WriteLine(_score);

            // Loop through list and save each goal
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goals file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            // First line is always the score
            _score = int.Parse(lines[0]);

            // Skip first line (score) and read rest of goals
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                // Split string into Type (index 0) and Description (index 1)
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string goalDetails = parts[1];

                // Split Description by '|'
                string[] attributes = goalDetails.Split('|');
                string goalName = attributes[0];
                string goalDescription = attributes[1];
                int goalPoints = int.Parse(attributes[2]);

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(attributes[3]);
                    _goals.Add(new SimpleGoal(goalName, goalDescription, goalPoints, isComplete));
                }
                else if (goalType == "EternalGoal")
                {
                    int timesCompleted = int.Parse(attributes[3]);
                    _goals.Add(new EternalGoal(goalName, goalDescription, goalPoints, timesCompleted));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int goalBonus = int.Parse(attributes[3]);
                    int goalTarget = int.Parse(attributes[4]);
                    int amountCompleted = int.Parse(attributes[5]);

                    _goals.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, goalTarget, goalBonus, amountCompleted));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}