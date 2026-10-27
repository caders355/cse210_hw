/*
Inventory Program - Main Program

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
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

using System;

class Program
{
    static void Main(string[] args)
    {
        InventoryManager manager = new InventoryManager();
        string filename = "Inventory.txt";

        // Try to load any previously saved date when the program starts
        manager.LoadInventory(filename);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n~~ Inventory Management System ~~");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Display All Items");
            Console.WriteLine("3. Display Category Summary");
            Console.WriteLine("4. Save and Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                // 

                    break;

                case "2":
                    //
                    manager.DisplayAllItems();
                    break;
                
                case "3":
                    //
                    manager.DisplayCategorySummary();
                    break;
                
                case "4":
                    //
                    manager.SaveInventory(filename);
                    running = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid selection, try again.");
                    break;
            }
        }
    }
}