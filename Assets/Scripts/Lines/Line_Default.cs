using UnityEngine;
using System.Collections;
using System;

public class Line_Default : Line
{
    Color line_color;

    public override void ChangeColor()
    {
        Color[] colors = GameController.game_controller.GetLvlData().colors;
        Color new_color=colors[UnityEngine.Random.Range(0, colors.Length)];
        line_color = new_color;
        base.sprite_rend.color = new_color;
    }
    protected override void InitLine()
    {
        
    }
    protected override void CheckIfPassed()
    {
        Ball.ball.LinePassed(line_color);
    }
}
