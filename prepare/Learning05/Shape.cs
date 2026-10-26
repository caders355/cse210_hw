/**/

using System;
using System.Drawing;

public class Shape
{
    private string _shapeColor;

    public Shape(string color)
    {
        _shapeColor = color;
    }

    public string GetColor()
    {
        return _shapeColor;
    }

    public void SetColor(string color)
    {
        _shapeColor = color;
    }

    
    public virtual double GetArea()
    {
        return 0.0;
    }
}