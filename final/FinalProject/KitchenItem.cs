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

    // 
    public KitchenItem(string itemId, string itemName, double itemValue, int itemQuantity, string itemDescription, string itemMaterial, bool isDiswasherSafe)
        : base(itemId, itemName, itemValue, itemQuantity, itemDescription)
    {
        _itemMaterial = itemMaterial;
        _isDishwasherSafe = isDiswasherSafe;
    }

    public override void DisplayItemInfo()
    {
        Console.WriteLine("");

        // 

    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}