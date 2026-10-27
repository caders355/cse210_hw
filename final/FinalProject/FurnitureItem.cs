/*
Inventory Program - FurnitureItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;

public class FurnitureItem : Item
{
    // Unique attributes for furniture items
    private string _itemDimensions;
    private string _itemPrimaryMaterial;
    private bool _canDisassemble;

    //
    public FurnitureItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemDimensions, string itemPrimaryMaterial, bool canDisassemble)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemDimensions = itemDimensions;
        _itemPrimaryMaterial = itemPrimaryMaterial;
        _canDisassemble = canDisassemble;
    }

    //
    public override void DisplayItemInfo()
    {
        Console.WriteLine();
    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}