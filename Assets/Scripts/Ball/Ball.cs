using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static Ball ball;
    BallMove ball_move;
    SpriteRenderer sprite_rend;

    int lines_checked;

	void Awake()
    {
        lines_checked = 0;
        ball = this;
	}

    void Start()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
        ball_move = GetComponent<BallMove>();
    }

	public void SetColor(Color color)
    {
        sprite_rend.color = color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            EventManager.TriggerEvent("LinePassed");

            if (sprite_rend.color == other.GetComponent<SpriteRenderer>().color)
            {
                lines_checked++;
                if (lines_checked >= GameController.game_controller.GetLvlData().lines_to_accel)
                {
                    ball_move.IncreaseSpeed(GameController.game_controller.GetLvlData().accel);
                    lines_checked = 0;
                }
            }
        }
    }
}
