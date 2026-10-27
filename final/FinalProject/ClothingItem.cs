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
    private string _itemSize;
    private string _itemMaterial;
    private string _itemColors;
    private string _itemCareInstructions;

    //
    public ClothingItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemSize, string itemMaterial, string itemColors, string itemCareInstructions)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemSize = itemSize;
        _itemMaterial = itemMaterial;
        _itemCareInstructions = itemCareInstructions;
    }

    // 
    public override void DisplayItemInfo()
    {
        Console.WriteLine($"[Clothing]");
    }

    //
    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}