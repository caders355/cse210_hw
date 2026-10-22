using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        //
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        //
        foreach(Entry entry in _entries)
        {
            //
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        //
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            // Loop through each Entry object in memory
            foreach (Entry entry in _entries)
            {
                // Write each entry on a line, with '|' as a separator
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }

    }

    public bool LoadFromFile(string file)
    {
        // Check if file exists
        if (!File.Exists(file))
        {
            Console.WriteLine($"\nError: Cound not find '{file}'. No entries were loaded.");
            // Tell main program it didn't work
            return false;
        }

        // Clear existing entries in memory to avoid duplicates
        _entries.Clear();

        // Read every line from the file into an array
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            // Split lines into parts with '|' separator
            string[] parts = line.Split('|');

            // Verify the line has 3 parts before parsing it
            if (parts.Length == 3)
            {
                Entry loadedEntry = new Entry();
                loadedEntry._date = parts[0];
                loadedEntry._promptText = parts[1];
                loadedEntry._entryText = parts[2];

                // Add the reconstructed entry back to list
                _entries.Add(loadedEntry);
            }

        }

        // Tell main program it was successful
        return true;

    }

}