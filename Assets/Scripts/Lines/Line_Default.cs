using UnityEngine;
using System.Collections;
using System;

public class Line_Default : Line
{
    Color line_color;
    
    
    public override void ChangeColor()
    {
        Color[] colors = SkinManager.skin_manager.GetCurrentSkin().colors;
         Color new_color=colors[UnityEngine.Random.Range(0, colors.Length)];
        //Color new_color = Color.green;
        Texture2D[] texture = TextureHandler.CreateTexture(new_color);
        SetTexture(texture);
        line_color = new_color;
        // base.sprite_rend.color = new_color;
    }
    public override void InitLine()
    {
        active = true;
        ChangeColor();
    }
    protected override void CheckIfPassed()
    {
        //if ((active) && (tran.position.y - height <= Ball.ball.collision_point.position.y))
        //{
           // Debug.DrawLine(new Vector3(1.0f, tran.position.y - height, 0.0f),
            //new Vector3(1.0f, tran.position.y + height, 0.0f), Color.black, 10.0f);
            anim.BeginAnimation();
            Ball.ball.LinePassed(line_color);
            active = false;
        //}
    }

    
}
