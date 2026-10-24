/*
Scripture Memorizer - Scripture Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Split raw text string into a list of word objects
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text by spaces and create Word object for each piece
        string[] splitText = text.Split(' ');
        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    // Hide a specified number of words randomly
    public void HideRandomWords(int numberToHide)
    {
        // Get indices of words not already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If no visible words left, don't try to Hide()
        if (visibleWords.Count == 0) return;

        Random rand = new Random();

        // Make sure not to hide more words than are actually visible
        int countToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < countToHide; i++)
        {
            // Pick random index from visible words index
            int index = rand.Next(visibleWords.Count);
            
            // Hide selected word
            visibleWords[index].Hide();

            // Prevent picking the same word 2 times in one round
            visibleWords.RemoveAt(index); 
        }
    }

    // Returns the reference and all words (hidden and visible) as one string
    public string GetDisplayText()
    {
        // Get formatted reference
        string refText = _reference.GetDisplayText();

        // Get the display text of all words, separated by spaces
        List<string> wordStrings = _words.Select(w => w.GetDisplayText()).ToList();
        string scriptureText = string.Join(" ", wordStrings);

        // Combine them
        return $"{refText} {scriptureText}";
    }

    // Checks if every single word in the scripture is currently hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    // Unhides words to display after completion
    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }
}