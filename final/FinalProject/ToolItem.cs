/*
Inventory Program - ToolItem [Child of Item] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;

public class ToolItem : Item
{
    // Unique attributes for tool items
    private string _itemSubcategory;
    private string _itemPowerType;
    // private string

    // 
    public ToolItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemSubcategory, string itemPowerType)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemSubcategory = itemSubcategory;
        _itemPowerType = itemPowerType;
    }

    //
    public override void DisplayItemInfo()
    {
        throw new NotImplementedException();
    }

    //
    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}