using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instance of objects needed for the program
        Journal journal = new Journal();
        PromptGen promptGen = new PromptGen();

        // Variable to keep program running
        bool programActive = true;

        while (programActive)
        {
            // Display menu options to user
            Console.WriteLine("Please choose one of the following actions:");
            Console.WriteLine("1. Write Entry");
            Console.WriteLine("2. Display All Entries");
            Console.WriteLine("3. Load An Entry");
            Console.WriteLine("4. Save An Entry");
            Console.WriteLine("5. Quit");

            // Take user choice
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                // Get a random prompt from the prompt generator
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine($"{prompt}");

                // Read user's response (entry)
                string userResponse = Console.ReadLine();

                // Get current date as a formatted string
                string date = DateTime.Now.ToShortDateString();

                // Create a new entry object and assign attributes
                Entry newEntry = new Entry();
                newEntry._date = date;
                newEntry._promptText = prompt;
                newEntry._entryText = userResponse;

                // Add the new entry object to the journal list
                journal.AddEntry(newEntry);
            }

            else if (userChoice == "2")
            {
                // Display all journal entries currently in memory
                journal.DisplayEntries();
            }

            else if (userChoice == "3")
            {
                // Ask for filename, then tell the journal to load the entries from it
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine().Trim();

                // Returns true if successful, false if file doesn't exist
                if (journal.LoadFromFile(filename))
                {
                Console.WriteLine($"Journal successfully loaded from {filename}.\n");

                // Display entries after loaded
                journal.DisplayEntries();
                }
            }

            else if (userChoice == "4")
            {
                // Ask for filename, then tell the journal to save the file to it
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine().Trim();
                journal.SaveToFile(filename);
                Console.WriteLine($"Journal successfully saved to {filename}.");
            }

            else if (userChoice == "5")
            {
                // Exit menu loop
                programActive = false;
            }

        }
    
    }

}