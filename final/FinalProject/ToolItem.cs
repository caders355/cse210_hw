/*
Inventory Program - ToolItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class ToolItem : Item
{
    // Unique attributes for tool items
    private string _itemSubcategory;
    private string _itemBrand;
    private string _itemSerialNumber;
    private string _itemPowerType;

    // Use base to pass shared attributes to parent constructor 
    public ToolItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemSubcategory, string itemBrand, string itemSerialNumber, string itemPowerType)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemSubcategory = itemSubcategory;
        _itemBrand = itemBrand;
        _itemSerialNumber = itemSerialNumber;
        _itemPowerType = itemPowerType;
    }

    // Changes the way the parent method functions
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Tool] {_itemName} ({_itemSubcategory}) - ${_itemValue}");
        Console.WriteLine($"    {_itemBrand} {_itemPowerType}");
        Console.WriteLine($"    Qty: {_itemQuantity}");
        Console.WriteLine($"    SN: {_itemSerialNumber}");
        Console.WriteLine($"    Item Description: {_itemDescription}");
    }

    // Format the data for saving to text file
    public override string GetStringRepresentation()
    {
        // Use '|' as delimiter
        return $"ToolItem|{_itemId}|{_itemName}|{_itemValue}|{_itemQuantity}|{_itemDescription}|{_itemSubcategory}|{_itemBrand}|{_itemSerialNumber}|{_itemPowerType}";
    }
}