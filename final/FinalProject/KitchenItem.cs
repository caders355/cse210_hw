/*
Inventory Program - KitchenItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;

public class KitchenItem : Item
{
    // Unique attributes for kitchen items
    private string _itemSubcategory;
    private string _itemMaterial;
    private bool _isDishwasherSafe;

    // Use base to pass shared attributes to parent constructor 
    public KitchenItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemSubcategory, string itemMaterial, bool isDiswasherSafe)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemSubcategory = itemSubcategory;
        _itemMaterial = itemMaterial;
        _isDishwasherSafe = isDiswasherSafe;
    }

    // Changes the way the parent method functions
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Kitchen] {_itemName} ({_itemSubcategory}) - ${_itemValue}");
        Console.WriteLine($"    {_itemMaterial}");
        Console.WriteLine($"    Qty: {_itemQuantity}");
        Console.WriteLine($"    Dishwasher Safe: {_isDishwasherSafe}");
        Console.WriteLine($"    Item Description: {_itemDescription}");
    }

    // Format the data for saving to text file
    public override string GetStringRepresentation()
    {
        // Use '|' as delimiter
        return $"KitchenItem|{_itemId}|{_itemName}|{_itemValue}|{_itemQuantity}|{_itemDescription}|{_itemSubcategory}|{_itemMaterial}|{_isDishwasherSafe}";
    }
}