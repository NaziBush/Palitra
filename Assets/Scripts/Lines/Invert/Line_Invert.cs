using UnityEngine;
using System.Collections.Generic;
using System;

public class Line_Invert : Line
{
    public Part[] parts;

    protected override void ChangeColor()
    {
        foreach (Part item in parts)
        {
            item.SetRandomColor();
        }
    }

    protected override void CheckIfPassed()
    {
        List<Color> colors=new List<Color>();
        foreach (Part item in parts)
        {
            colors.Add(item.GetColor());
        }

        Ball.ball.LinePassed(colors, true);
    }
}
