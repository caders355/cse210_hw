/*
Inventory Program - InventoryManager Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;
using System.Collections.Generic;
using System.IO;

public class InventoryManager
{
    // Encapsulated list holding all inventory items
    // Use base (Item) class to hold any child class
    private List<Item> _inventoryList;

    // Constructor initializes empty list
    public InventoryManager()
    {
        _inventoryList = new List<Item>();
    }

    // Adds an item to the inventory
    public void AddItem(Item item)
    {
        _inventoryList.Add(item);
        Console.WriteLine($"{item.GetName()} added successfully.");
    }

    // Searches for item by ID, removes it
    public void RemoveItem(string itemId)
    {
        // 
        for (int i = 0; i < _inventoryList.Count; i++)
        {
            if (_inventoryList[i].GetId() == itemId)
            {
                string itemName = _inventoryList[i].GetName();
                _inventoryList.RemoveAt(i); // Removes the item and the current index
                Console.WriteLine($"Success: {itemName} (ID: {itemId}) has been removed.");
                return; // Exit method once found
            }
        }
    }

    // Loops through list and displays info for each item
    public void DisplayAllItems()
    {
        if (_inventoryList.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        foreach (Item item in _inventoryList)
        {
            // Automatically call correct DisplayItemInfo(), based on child type
            Console.WriteLine(new string('-', 20));
            item.DisplayItemInfo();
            Console.WriteLine(new string('-', 20));
        }
    }

    // Counts items based on derived class type
    public void DisplayCategorySummary()
    {
        if (_inventoryList.Count == 0)
        {
            Console.WriteLine("Inventory is empty, not summary is available.");
            return;
        }

        // Variables to hold the count for each category
        int techCount = 0;
        int toolCount = 0;
        int kitchenCount = 0;
        int clothingCount = 0;
        int furnitureCount = 0;

        // Loop through the list and check which child class each item belongs to
        foreach (Item item in _inventoryList)
        {
            // 'is' checks actual runtime type of the object
            if (item is TechItem)
            {
                techCount++;
            }
            else if (item is ToolItem)
            {
                toolCount++;
            }
            else if (item is KitchenItem)
            {
                kitchenCount++;
            }
            else if (item is ClothingItem)
            {
                clothingCount++;
            }
            else if (item is FurnitureItem)
            {
                furnitureCount++;
            }
        }

        // Print the totals
        Console.WriteLine("\n--- Category Summary ---");
        Console.WriteLine($"Tech Items:      {techCount}");
        Console.WriteLine($"Tool Items:      {toolCount}");
        Console.WriteLine($"Kitchen Items:   {kitchenCount}");
        Console.WriteLine($"Clothing Items:  {clothingCount}");
        Console.WriteLine($"Furniture Items: {furnitureCount}");
        Console.WriteLine(new string('-', 24));
        Console.WriteLine($"Total Items:     {_inventoryList.Count}");
    }

    // Iterates through inventory and calculates total monetary value
    public double CalculateTotalInventoryValue()
    {
        double totalValue = 0.0;

        foreach (Item item in _inventoryList)
        {
            // 
            totalValue += (item.GetValue() * item.GetQuantity());
        }

        return totalValue;
    }

    // Saves current state of the inventory to a text file
    public void SaveInventory(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Item item in _inventoryList)
            {
                // Automatically gets the correct formatted string for each child class
                outputFile.WriteLine(item.GetStringRepresentation());
            }
        }
    }

    // Reads a text file, rebuilds inventory list
    public void LoadInventory(string filename)
    {
        // Check if file exists
        if (System.IO.File.Exists(filename))
        {
            // Read all lines from text file into an array of strings
            string[] lines = System.IO.File.ReadAllLines(filename);

            // Loop through each line
            foreach (string line in lines)
            {
                // Split line into individual parts
                string[] parts = line.Split('|');

                // First 6 parts are always same type
                string itemType = parts[0];
                string itemId = parts[1];
                string itemName = parts[2];
                double itemValue = double.Parse(parts[3]);
                int itemQuantity = int.Parse(parts[4]);
                string itemDescription = parts[5];

                // Check itemType and instantiate the right child class
                if (itemType == "TechItem")
                {
                    string itemSubcategory = parts[6];
                    string itemBrand = parts[7];
                    string itemSerialNumber = parts[8];

                    Item newTech = new TechItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemBrand, itemSerialNumber);
                    _inventoryList.Add(newTech);
                }
                else if (itemType == "ToolItem")
                {
                    string itemSubcategory = parts[6];
                    string itemBrand = parts[7];
                    string itemSerialNumber = parts[8];
                    string itemPowerType = parts[9];

                    Item newTool = new ToolItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemBrand, itemSerialNumber, itemPowerType);
                    _inventoryList.Add(newTool);
                }
                else if (itemType == "KitchenItem")
                {
                    string itemSubcategory = parts[6];
                    string itemMaterial = parts[7];
                    bool isDiswasherSafe = bool.Parse(parts[8]);

                    Item newKitchen = new KitchenItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemMaterial, isDiswasherSafe);
                    _inventoryList.Add(newKitchen);
                }
                else if (itemType == "ClothingItem")
                {
                    string itemSubcategory = parts[6];
                    string itemSize = parts[7];
                    string itemMaterial = parts[8];
                    string itemColors = parts[9];
                    string itemCareInstructions = parts[10];

                    Item newClothing = new ClothingItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemSize, itemMaterial, itemColors, itemCareInstructions);
                    _inventoryList.Add(newClothing);
                }
                else if (itemType == "FurnitureItem")
                {
                    string itemDimensions = parts[6];
                    string itemPrimaryMaterial = parts[7];
                    string itemPrimaryColor = parts[8];
                    bool canDisassemble = bool.Parse(parts[9]);

                    Item newFurniture = new FurnitureItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemDimensions, itemPrimaryMaterial, itemPrimaryColor, canDisassemble);
                    _inventoryList.Add(newFurniture);
                }
            }
        }
    }
}