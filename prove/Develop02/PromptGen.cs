using System;
using System.Collections.Generic;

public class PromptGen
{
    // Create a list of the prompts
    public List<string> _prompts = new List<string>
    {
        "What was my most interesting interaction of the day?",
        "What was my favorite moment of today?",
        "How did I see the Lord today?",
        "What is something new I learned or that I am now excited about?",
        "If I could do over a part of today, what would it be?",
        "What did I do better today?",
        "What is something I want to do better tomorrow?"
    };

    // Picks and returns a random prompt
    public string GetRandomPrompt()
    {
        // Generate a random index between 0 and the number of prompts, minus 1
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

}