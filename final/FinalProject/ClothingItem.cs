/*
Inventory Program - ClothingItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;

public class ClothingItem : Item
{
    // Unique attributes for clothing items
    private string _itemSubcategory;
    private string _itemSize;
    private string _itemMaterial;
    private string _itemColors;
    private string _itemCareInstructions;

    // Use base to pass shared attributes to parent constructor
    public ClothingItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemSubcategory, string itemSize, string itemMaterial, string itemColors, string itemCareInstructions)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemSubcategory = itemSubcategory;
        _itemSize = itemSize;
        _itemMaterial = itemMaterial;
        _itemColors = itemColors;
        _itemCareInstructions = itemCareInstructions;
    }

    // Changes the way the parent method functions 
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Clothing] {_itemName} ({_itemSubcategory}) - ${_itemValue}");
        Console.WriteLine($"    {_itemSize} {_itemMaterial} {_itemColors}");
        Console.WriteLine($"    Qty: {_itemQuantity}");
        Console.WriteLine($"    Care Instructions: {_itemCareInstructions}");
        Console.WriteLine($"    Item Description: {_itemDescription}");
    }

    // Format the data for saving to text file
    public override string GetStringRepresentation()
    {
        // Use '|' as delimiter
        return $"ClothingItem|{_itemId}|{_itemName}|{_itemValue}|{_itemQuantity}|{_itemDescription}|{_itemSubcategory}|{_itemSize}|{_itemMaterial}|{_itemColors}|{_itemCareInstructions}";
    }
}