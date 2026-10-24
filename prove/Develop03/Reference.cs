/*
Scripture Memorizer - Reference Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endverse;

    // Construct a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endverse = verse;
    }

    // Construct a multi-verse
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endverse = endVerse;
    }

    // Return cleanly formatted string of reference
    public string GetDisplayText()
    {
        if (_startVerse == _endverse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endverse}";
        }
    }
}