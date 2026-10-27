/*
Inventory Program - Main Program

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

/*
Program Components:
    FinalProject.csproj
        Program.cs
        InventoryManager.cs
        Item.cs
        TechItem.cs
        ToolItem.cs
        KitchenItem.cs
        ClothingItem.cs
        FurnitureItem.cs
        Inventory.txt
*/

/*
Exceeding Requirements
1. Data is stored automatically in a local file, and is ready automatically when the program is run
2. DisplayCategorySummary() evaluates runtime type of each item to categorize a mixed data list
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // Instantiate controller to manage data
        InventoryManager manager = new InventoryManager();
        string filename = "Inventory.txt";

        // Try to load any previously saved date when the program starts
        manager.LoadInventory(filename);

        // Main loop
        bool running = true;
        while (running)
        {
            // Display main menu
            Console.WriteLine("\n~~ Inventory Management System ~~");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Display All Items");
            Console.WriteLine("4. Display Category Summary");
            Console.WriteLine("5. View Total Inventory Value");
            Console.WriteLine("6. Save and Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                case "1": // Add New Item
                    Console.WriteLine("\nWhat type of item are you adding?");
                    Console.WriteLine("1. Tech");
                    Console.WriteLine("2. Tool");
                    Console.WriteLine("3. Kitchen");
                    Console.WriteLine("4. Clothing");
                    Console.WriteLine("5. Furniture");
                    Console.Write("Select category: ");
                    string userChoice = Console.ReadLine();

                    // Gather base item properties
                    Console.Write("Enter ID: ");
                    string itemId = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter Value: ");
                    double itemValue = double.Parse(Console.ReadLine());
                    Console.Write("Enter Quantity: ");
                    int itemQuantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter Description: ");
                    string itemDescription = Console.ReadLine();

                    Item newItem = null; // Declare base Item, instantiate a specific child below

                    // Get specific properties based on user input
                    if (userChoice == "1") // Tech
                    {
                        Console.Write("Subcategory: ");
                        string itemSubcategory = Console.ReadLine();
                        Console.Write("Brand: ");
                        string itemBrand = Console.ReadLine();
                        Console.Write("Serial Number: ");
                        string itemSerialNumber = Console.ReadLine();

                        // Insantiate TechItem, store in Item variable
                        newItem = new TechItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemBrand, itemSerialNumber);
                    }
                    else if (userChoice == "2") // Tool
                    {
                        Console.Write("Subcategory: ");
                        string itemSubcategory = Console.ReadLine();
                        Console.Write("Brand: ");
                        string itemBrand = Console.ReadLine();
                        Console.Write("Serial Number: ");
                        string itemSerialNumber = Console.ReadLine();
                        Console.Write("Power Type: ");
                        string itemPowerType = Console.ReadLine();

                        newItem = new ToolItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemBrand, itemSerialNumber, itemPowerType);
                    }
                    else if (userChoice == "3") // Kitchen
                    {
                        Console.Write("Subcategory: ");
                        string itemSubcategory = Console.ReadLine();
                        Console.Write("Material: ");
                        string itemMaterial = Console.ReadLine();
                        Console.Write("Dishwasher Safe? ");
                        bool isDiswasherSafe = bool.Parse(Console.ReadLine());

                        newItem = new KitchenItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemMaterial, isDiswasherSafe);
                    }
                    else if (userChoice == "4") // Clothing
                    {
                        Console.Write("Subcategory: ");
                        string itemSubcategory = Console.ReadLine();
                        Console.Write("Size: ");
                        string itemSize = Console.ReadLine();
                        Console.Write("Material: ");
                        string itemMaterial = Console.ReadLine();
                        Console.Write("Item Colors: ");
                        string itemColors = Console.ReadLine();
                        Console.Write("Care Instructions: ");
                        string itemCareInstructions = Console.ReadLine();

                        newItem = new ClothingItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemSubcategory, itemSize, itemMaterial, itemColors, itemCareInstructions);
                    }
                    else if (userChoice == "5") // Furniture
                    {
                        Console.Write("Dimensions: ");
                        string itemDimensions = Console.ReadLine();
                        Console.Write("Primary Material: ");
                        string itemPrimaryMaterial = Console.ReadLine();
                        Console.Write("Primary Color: ");
                        string itemPrimaryColor = Console.ReadLine();
                        Console.Write("Can Disassemble? ");
                        bool canDisassemble = bool.Parse(Console.ReadLine());

                        newItem = new FurnitureItem(itemId, itemName, itemValue, itemQuantity, itemDescription, itemDimensions, itemPrimaryMaterial, itemPrimaryColor, canDisassemble);
                    }

                    // Pass newly created object to the manager to store it
                    if (newItem != null)
                    {
                        manager.AddItem(newItem);
                    }
                    else
                    {
                        Console.WriteLine("Invalid category, item could not be added.");
                    }
                    break;

                case "2": // Remove Item
                    Console.Write("Enter the ID of the item you want to remove: ");
                    string idToRemove = Console.ReadLine();
                    manager.RemoveItem(idToRemove); // Pass ID to manager class
                    break;

                case "3": // Display All
                    manager.DisplayAllItems();
                    break;
                
                case "4": // Display Summary
                    manager.DisplayCategorySummary();
                    break;
                
                case "5": // Calculate Value
                    double total = manager.CalculateTotalInventoryValue();
                    Console.WriteLine($"Total Inventory Value: {total:C}");
                    break;

                case "6": // Save and Exit
                    manager.SaveInventory(filename);
                    running = false; // Break the while loop
                    break;
                
                default:
                    Console.WriteLine("Invalid selection, try again.");
                    break;
            }
        }
    }
}