/*
Inventory Program - FurnitureItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [1.0]
*/

using System;

public class FurnitureItem : Item
{
    // Unique attributes for furniture items
    private string _itemDimensions;
    private string _itemPrimaryMaterial;
    private string _itemPrimaryColor;
    private bool _canDisassemble;

    // Use base to pass shared attributes to parent constructor
    public FurnitureItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemDimensions, string itemPrimaryMaterial, string itemPrimaryColor, bool canDisassemble)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemDimensions = itemDimensions;
        _itemPrimaryMaterial = itemPrimaryMaterial;
        _itemPrimaryColor = itemPrimaryColor;
        _canDisassemble = canDisassemble;
    }

    // Changes the way the parent method functions
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Furniture] {_itemName} - ${_itemValue}");
        Console.WriteLine($"    {_itemDimensions} {_itemPrimaryMaterial} {_itemPrimaryColor}");
        Console.WriteLine($"    Qty: {_itemQuantity}");
        Console.WriteLine($"    Can Disassemble: {_canDisassemble}");
        Console.WriteLine($"    Item Description: {_itemDescription}");
    }

    // Format the data for saving to text file
    public override string GetStringRepresentation()
    {
        // Use '|' as delimiter
        return $"FurnitureItem|{_itemId}|{_itemName}|{_itemValue}|{_itemQuantity}|{_itemDescription}|{_itemDimensions}|{_itemPrimaryMaterial}|{_itemPrimaryColor}|{_canDisassemble}";
    }
}