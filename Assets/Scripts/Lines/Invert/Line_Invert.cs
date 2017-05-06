using UnityEngine;
using System.Collections.Generic;
using System;

public class Line_Invert : Line
{
    public Part[] parts;

    public override void ChangeColor()
    {
        parts[0].SetColor(GameController.game_controller.GetLvlData().
                colors[UnityEngine.Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)]);
        if (parts.Length == 2)
        {
            List<Color> colors = new List<Color>();
            Color part0_color = parts[0].GetColor();
            for (int i = 0; i < GameController.game_controller.GetLvlData().colors.Length; i++)
            {
                if (GameController.game_controller.GetLvlData().colors[i] != part0_color)
                {
                    colors.Add(GameController.game_controller.GetLvlData().colors[i]);
                }
            }

            parts[1].SetColor(colors[UnityEngine.Random.Range(0, colors.Count)]);
        }
        //foreach (Part item in parts)
        //{
        //    item.SetRandomColor();
        //}
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

    //protected override void InitLine()
    //{
    //    foreach (Part item in parts)
    //    {
    //        item.SetGreyColor();
    //    }
    //}
}
