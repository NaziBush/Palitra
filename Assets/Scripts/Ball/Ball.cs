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
    bool shield;

    int lines_checked;

	void Awake()
    {
        lines_checked = 0;
        ball = this;
        shield = false;
        ball_move = GetComponent<BallMove>();
        tran = GetComponent<Transform>();
        SetColor(GameController.game_controller.GetLvlData().colors[0]);
    }

    void Start()
    {
        
    }

	public void SetColor(Color color)
    {
        sprite_rend.color = color;
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
        EventManager.TriggerEvent("LinePassed");
        lines_checked++;

        if (line_color == sprite_rend.color)
        {
            if (lines_checked >= GameController.game_controller.GetLvlData().lines_to_accel)
            {
                ball_move.IncreaseSpeed(GameController.game_controller.GetLvlData().accel);
                lines_checked = 0;
            }
        }
        else
        {
            //print(line_color);
            //print(sprite_rend.color);
            if (shield)
            {
                shield = false;
            }
            else
            {
                GameController.game_controller.GameOver();
            }
        }
    }


    public void LinePassed(List<Color> line_color,bool invert)
    {
        EventManager.TriggerEvent("LinePassed");
        lines_checked++;

        bool passed=false;

        foreach (Color item in line_color)
        {
            if (item == sprite_rend.color)
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
            //print(line_color);
            //print(sprite_rend.color);
            if (shield)
            {
                shield = false;
            }
            else
            {
                GameController.game_controller.GameOver();
            }
        }
    }
    void ChangeLvl()
    {
        shield = true;
        //SetColor(GameController.game_controller.GetLvlData().colors[0]);
    }


    

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Line"))
    //    {
    //        EventManager.TriggerEvent("LinePassed");

    //        if (sprite_rend.color == other.GetComponent<SpriteRenderer>().color)
    //        {
    //            lines_checked++;
    //            if (lines_checked >= GameController.game_controller.GetLvlData().lines_to_accel)
    //            {
    //                ball_move.IncreaseSpeed(GameController.game_controller.GetLvlData().accel);
    //                lines_checked = 0;
    //            }
    //        }
    //        else
    //        {
    //            if (shield)
    //            {
    //                shield = false;
    //            }
    //            else
    //            {
    //                GameController.game_controller.GameOver();
    //            }
    //        }
    //    }
    //}
}
