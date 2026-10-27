/*
Inventory Program - InventoryManager Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;
using System.Collections.Generic;
using System.IO;

public class InventoryManager
{
    // 
    private List<Item> _inventoryList;

    // 
    public InventoryManager()
    {
        _inventoryList = new List<Item>();
    }

    // Adds an item to the inventory
    public void AddItem(Item item)
    {
        _inventoryList.Add(item);
        Console.WriteLine($"{item} added successfully.");
    }

    // 
    public void RemoveItem()
    {
        
    }

    // 
    public void DisplayAllItems()
    {
        // 
        if (_inventoryList.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        // 
        foreach (Item item in _inventoryList)
        {
            // 
            item.DisplayItemInfo();
            Console.WriteLine(new string('-', 20));
        }
    }

    // 
    public void DisplayCategorySummary()
    {
        
    }

    // 
    public double CalculateTotalInventoryValue()
    {
        return 0.0;
    }

    // 
    public void SaveInventory(string filename)
    {
        // 
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Item item in _inventoryList)
            {
                // 
                outputFile.WriteLine(item.GetStringRepresentation());
            }
        }
    }

    public void LoadInventory(string filename)
    {
        
    }
}