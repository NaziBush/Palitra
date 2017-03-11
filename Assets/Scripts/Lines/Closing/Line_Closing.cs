using UnityEngine;
using System.Collections.Generic;

public class Line_Closing : Line
{

    public Part[] parts;
    Runtime_Closing runt_close;

    public override void ChangeColor()
    {
        foreach (Part item in parts)
        {
            item.SetRandomColor();
        }
    }

    protected override void InitLine()
    {
        runt_close = GetComponent<Runtime_Closing>();
    }
    protected override void CheckIfPassed()
    {
        List<Color> colors = new List<Color>();
        foreach (Part item in parts)
        {
            colors.Add(item.GetColor());
        }

        Ball.ball.LinePassed(colors, true);
    }

    protected override void CheckIfCrossed()
    {
        if ((runt_close.CheckIfCrossBall())&&(active))
        {
            CheckIfPassed();
            active = false;
        }
    }

    protected override void OnEnable()
    {
        active = true;
        foreach (Part item in parts)
        {
            item.SetGreyColor();
        }
    }
}
