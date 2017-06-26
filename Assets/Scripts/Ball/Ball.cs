using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static Ball ball;
    [HideInInspector]
    public Transform tran;
    BallMove ball_move;
    public SpriteRenderer sprite_rend;
    [HideInInspector]
    public float size_x;
    bool shield;
    public Transform collision_point;
    public Color ball_color;

    int lines_checked;

	void Awake()
    {
        lines_checked = 0;
        ball = this;
        shield = false;
        ball_move = GetComponent<BallMove>();
        tran = GetComponent<Transform>();
        SetColor(SkinManager.skin_manager.GetCurrentSkin().colors[0]);
        size_x = sprite_rend.sprite.bounds.extents.x * tran.localScale.x;
    }

	public void SetColor(Color color)
    {
        if (color!= ball_color)
        {
            ball_color = color;
            sprite_rend.color = color;
            EventManager.TriggerEvent("BallColorChanged");
        }
        
    }

    void OnEnable()
    {
        EventManager.StartListening("ChangeLvl", ChangeLvl);
    }
    void OnDisable()
    {
        EventManager.StopListening("ChangeLvl", ChangeLvl);
    }

    public void LinePassed(Color line_color)
    {
        lines_checked++;
        if (((Vector4)line_color - (Vector4)sprite_rend.color).magnitude<0.01f)
        {
            if (lines_checked >= GameController.game_controller.GetLvlData().lines_to_accel)
            {
                ball_move.IncreaseSpeed(GameController.game_controller.GetLvlData().accel);
                lines_checked = 0;
            }
        }
        else
        {
            if (shield)
            {
                shield = false;
            }
            else
            {
                GameController.game_controller.GameOver();
            }
        }
        EventManager.TriggerEvent("LinePassed");
        
    }
    public int GetLinesCheckedNumber()
    {
        return lines_checked;
    }

    public void LinePassed(List<Color> line_color,bool invert)
    {
        bool passed=false;

        foreach (Color item in line_color)
        {
            if ((((Vector4)item - (Vector4)sprite_rend.color).magnitude < 0.01f))
            {
                passed = true;
                break;
            }
        }

        if (invert)
            passed = !passed;

        if (passed)
        {
            if (lines_checked >= GameController.game_controller.GetLvlData().lines_to_accel)
            {
                ball_move.IncreaseSpeed(GameController.game_controller.GetLvlData().accel);
                lines_checked = 0;
            }
        }
        else
        {
            if (shield)
            {
                shield = false;
            }
            else
            {
                GameController.game_controller.GameOver();
            }
        }
        EventManager.TriggerEvent("LinePassed");
        lines_checked++;
    }

    void ChangeLvl()
    {
        shield = true;
    }
}
