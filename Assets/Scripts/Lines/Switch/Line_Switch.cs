using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line_Switch : Line
{
    float dist;
    //float saved_dist;
    //Color line_color;


    public override void ChangeColor()
    {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < SkinManager.skin_manager.GetCurrentSkin().colors.Length; i++)
            {
                if (SkinManager.skin_manager.GetCurrentSkin().colors[i] != base.sprite_rend.color)
                {
                    colors.Add(SkinManager.skin_manager.GetCurrentSkin().colors[i]);
                }
            }

        base.sprite_rend.color=colors[UnityEngine.Random.Range(0, colors.Count)];

        //Color[] colors = SkinManager.skin_manager.GetCurrentSkin().colors;
        //Color new_color = colors[UnityEngine.Random.Range(0, colors.Length)];
        //line_color = new_color;
        //base.sprite_rend.color = new_color;
    }
    public override void InitLine()
    {
        active = true;
        //saved_dist = SpawnWaves.spawn.dist;
        dist = GameController.game_controller.GetLvlData().switch_prop.dist;
        ChangeColor();
        StartCoroutine(SwitchColor());
    }
    protected override void CheckIfPassed()
    {
        
       Ball.ball.LinePassed(base.sprite_rend.color);
        
    }
    protected override void OnEnable()
    {
        
    }
    IEnumerator SwitchColor()
    {
        //print("dfh");
        //yield return new WaitForSeconds(0.2f);
        while (gameObject.activeSelf)
        {
            //print((active) && (tran.position.y - height - Ball.ball.tran.position.y > dist));
            //if ((active) && (tran.position.y - height - Ball.ball.tran.position.y > saved_dist))
            if ((active) && (tran.position.y - height - Ball.ball.tran.position.y > dist))
            {
                //line.ChangeColor(SkinManager.skin_manager.GetCurrentSkin().colors[Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)]);
                ChangeColor();
                //print("dfh");
            }
            yield return new WaitForSeconds(GameController.game_controller.GetLvlData().switch_prop.time_to_change);
        }
        
    }

}
