/*
Mindfulness Program - Main Program

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

/*
Exceeding Requirements:
1. Added session tracker to count how many activities a user completes in a session
2. Made sure that questions and prompts in ReflectingActivity do not repeat until they have all been used in the session
3. Created a custom progress bar animation rather than a standard countdown timer
*/

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int activitiesCompleted = 0;
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start Breathing Activity");
            Console.WriteLine(" 2. Start Reflecting Activity");
            Console.WriteLine(" 3. Start Listing Activity");
            Console.WriteLine(" 4. Quit");
            Console.WriteLine($"\nActivities completed this session: {activitiesCompleted}");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                activitiesCompleted++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                activitiesCompleted++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                activitiesCompleted++;
            }
        }
    }
}