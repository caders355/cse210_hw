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
    private string _itemType;
    private string _itemBrand;
    private string _itemSerialNumber;

    // 
    public TechItem(string id, string name, double value, int quantity, string description, string itemType, string itemBrand, string itemSerialNumber)
        : base(id, name, value, quantity, description)
    {
        _itemType = itemType;
        _itemBrand = itemBrand;
        _itemSerialNumber = itemSerialNumber;
    }

    // 
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Tech] {_itemName} ({_itemBrand}) - ${_itemValue}");
        Console.WriteLine($"    {_itemBrand} {_itemType} - Qty: {_itemQuantity}");
        Console.WriteLine($"    SN: {_itemSerialNumber}");
        Console.WriteLine($"    Item Description: {_itemDescription}");
    }

    // Format the data for saving to text file
    public override string GetStringRepresentation()
    {
        // Use '|' as delimiter
        return $"TechItem|{_itemId}|{_itemName}|{_itemValue}|{_itemBrand}|{_itemType}|{_itemQuantity}|{_itemSerialNumber}|{_itemDescription}";
    }
}