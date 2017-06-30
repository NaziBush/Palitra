using UnityEngine;
using System.Collections;
using System;

public class Line_Default : Line
{
    Color line_color;
    static int same_colors = 1;
    
    public override void ChangeColor()
    {
        Color[] colors = SkinManager.skin_manager.GetCurrentSkin().colors;
         Color new_color=colors[UnityEngine.Random.Range(0, colors.Length)];
        if (new_color==line_color)
        {
            same_colors++;
        }
        if (same_colors>2)
        {
            Color[] avail_col = new Color[colors.Length - 1];
            int k = 0;
            for (int i=0;i<colors.Length;i++)
            {
                if (colors[i]!=line_color)
                {
                    avail_col[k] = colors[i];
                    k++;
                }
            }
            new_color = avail_col[UnityEngine.Random.Range(0, avail_col.Length)];
            same_colors = 1;
        }
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
