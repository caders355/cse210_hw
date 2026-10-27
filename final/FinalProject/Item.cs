/*
Inventory Program - Item [Parent of TechItem, ToolItem, KitchenItem, ClothingItem, FurnitureItem] Class

Author: [Cade P. Woolley]
Date: [Oct 2026]
Version: [2.0]
*/

using System;

// Create parent class(Item) for each category of item
public abstract class Item
{
    // Variables that will be accessed by child classes
    protected string _itemId;
    protected string _itemName;
    protected double _itemValue;
    protected int _itemQuantity;
    protected string _itemDescription;

    // Constructor to initialize base attributes
    public Item(string id, string name, double value, int quantity, string description)
    {
        _itemId = id;
        _itemName = name;
        _itemValue = value;
        _itemQuantity = quantity;
        _itemDescription = description;
    }

    // 
    public void UpdateQuantity(int amount)
    {
        _itemQuantity += amount;
    }

    // Each child class will use their own version of these methods
    public abstract void DisplayItemInfo();
    public abstract string GetStringRepresentation();

    // Getter for _itemId
    public string GetId()
    {
        return _itemId;
    }

    // Setter for _itemId
    public void SetId(string id)
    {
        _itemId = id;
    }

    // Getter for _itemName
    public string GetName()
    {
        return _itemName;
    }

    // Setter for _itemName
    public void SetName(string name)
    {
        _itemName = name;
    }

    // Getter for _itemValue
    public double GetValue()
    {
        return _itemValue;
    }

    // Setter for _itemValue
    public void SetValue(double value)
    {
        _itemValue = value;
    }

    // Getter for _itemQuantity
    public int GetQuantity()
    {
        return _itemQuantity;
    }

    // Setter for _itemQuantity
    public void SetQuantity(int quantity)
    {
        _itemQuantity = quantity;
    }

    // Getter for _itemDescription
    public string GetDescription()
    {
        return _itemDescription;
    }

    // Setter for _itemDescription
    public void SetDescription(string description)
    {
        _itemDescription = description;
    }
}