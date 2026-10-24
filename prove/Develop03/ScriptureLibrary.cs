/*
Scripture Memorizer - ScriptureLibrary Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();

    // Read file, parse data, adds Scriptures to library
    public void LoadFromFile(string filepath)
    {
        // If file doesn't exist, exit early
        if (!File.Exists(filepath)) return;

        string[] lines = File.ReadAllLines(filepath);
        foreach (string line in lines)
        {
            // Split by '|'
            string[] parts = line.Split('|');
            string book = parts [0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);

            // If part 3 empty, use startVerse. Otherwise, parse as endVerse
            int endVerse = string.IsNullOrEmpty(parts[3]) ? startVerse : int.Parse(parts[3]);
            string text = parts[4];

            // Create proper reference type
            Reference reference = (startVerse == endVerse)
                ? new Reference(book, chapter, startVerse)
                : new Reference(book, chapter, startVerse, endVerse);

            // Add fully constructed scripture to list
            _scriptures.Add(new Scripture(reference, text));
        }
    }

    // Return randomly selected scripture from list
    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0) return null;
        Random rand = new Random();
        int index = rand.Next(_scriptures.Count);
        return _scriptures[index];
    }
}