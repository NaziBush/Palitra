using UnityEngine;
using System.Collections.Generic;

public class Line_Closing : Line
{

    public Part[] parts;
    public bool same_color=false;
    Runtime_Closing runt_close;

    public override void ChangeColor()
    {
        if (same_color)
        {
            Color color= GameController.game_controller.GetLvlData().colors
                [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
            foreach (Part item in parts)
            {
                item.SetColor(color);
            }
        }
        else
        {
            foreach (Part item in parts)
            {
                item.SetRandomColor();
            }
        }
        
    }

    public override void InitLine()
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
        if ((runt_close.cross_ball)&&(active))
        {
            CheckIfPassed();
            active = false;
        }
    }

    protected override void OnEnable()
    {
        active = true;
        //foreach (Part item in parts)
        //{
        //    item.SetGreyColor();
        //}
        ChangeColor();
    }
}
