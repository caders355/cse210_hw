/*
Scripture Memorizer - Main Program

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

/* Exceeding Requirements:
1. Program loads a library of scriptures from an external file (Scriptures.txt)
2. Program selects a random scripture from the library
3. The algorithm for hiding words only selects from words that are not already hidden
4. The Word class preserves punctuation when converting text to _'s
5. Added a congrats message and reveal the scripture before exit
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize Library
        ScriptureLibrary library = new ScriptureLibrary();

        // Load file
        library.LoadFromFile("Scriptures.txt");

        // Get random scripture
        Scripture currentScripture = library.GetRandomScripture();

        // Catch, in case file doesn't exist or is empty
        if (currentScripture == null)
        {
            Reference fallbackRef = new Reference("1 Nephi", 3, 07);
            currentScripture = new Scripture(fallbackRef, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        }

        string userInput = "";

        // Main Loop. Runs until user types 'quit' or all words are hidden
        while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
        {
            // Clear console for clear view
            Console.Clear();

            // Display current state of scripture
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();

            // Prompt for user
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            userInput = Console.ReadLine();

            // If user presses ender, hide (3) words
            if (userInput.ToLower() != "quit")
            {
                currentScripture.HideRandomWords(3);
            }
        }

        // Final state, if exited loop because words completely hidden
        if (currentScripture.IsCompletelyHidden())
        {
            Console.Clear();          
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nGreat job! You have completely memorized this scripture! \nPress Enter to reveal the scripture. ");
            Console.ReadLine();

            // Reveal words before showing
            currentScripture.ShowAllWords();
            Console.WriteLine(currentScripture.GetDisplayText());
        }
    }
}