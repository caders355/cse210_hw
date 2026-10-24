/*
Scripture Memorizer - Word Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Creates new word and sets it to visible by default
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Method to hide word
    public void Hide() => _isHidden = true;

    // Method to show word
    public void Show() => _isHidden = false;

    // Method to check if word is currently hidden
    public bool IsHidden() => _isHidden;

    // Returns either original word or string of _'s
    public string GetDisplayText()
    {
        // If not hidden, return word normally
        if (!_isHidden) return _text;

        // Only replace alphanumeric letters with underscores
        char[] result = new char[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            char c = _text[i];
            result[i] = char.IsLetterOrDigit(c) ? '_' : c;
        }

        return new string(result);
    }
}