/*
Eternal Quest Program - Main Program

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

/*
Exceeding Requirements:
1. I added a persistent level that keeps track of a player's level and displays it to them
2. I added a progress bar for the player level
3. I added a _timesCompleted counter for eternal goals to the user can see how many times they have accomplished it
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}