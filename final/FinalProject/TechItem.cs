/*
Inventory Program - TechItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;
using System.Runtime.CompilerServices;

// Create child class (TechItem) for items in the tech category
public class TechItem : Item
{
    // Unique attributes for tech items
    private string _itemSubcategory;
    private string _itemBrand;
    private string _itemSerialNumber;

    // Use base to pass shared attributes to parent constructor
    public TechItem(string id, string name, double value, int quantity, string description, string itemSubcategory, string itemBrand, string itemSerialNumber)
        : base(id, name, value, quantity, description)
    {
        _itemSubcategory = itemSubcategory;
        _itemBrand = itemBrand;
        _itemSerialNumber = itemSerialNumber;
    }

    // Changes the way the parent method functions
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Tech] {_itemName} - ${_itemValue}");
        Console.WriteLine($"    {_itemBrand} {_itemSubcategory}");
        Console.WriteLine($"    Qty: {_itemQuantity}");
        Console.WriteLine($"    SN: {_itemSerialNumber}");
        Console.WriteLine($"    Item Description: {_itemDescription}");
    }

    // Format the data for saving to text file
    public override string GetStringRepresentation()
    {
        // Use '|' as delimiter
        return $"TechItem|{_itemId}|{_itemName}|{_itemValue}|{_itemQuantity}|{_itemDescription}|{_itemSubcategory}|{_itemBrand}|{_itemSerialNumber}";
    }
}