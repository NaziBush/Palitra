using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{
    SpriteRenderer sprite_rend;
    bool active;

    void Awake()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        active = true;
        Color[] colors = GameController.game_controller.GetLvlData().colors;
        sprite_rend.color = colors[Random.Range(0, colors.Length)];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if ((sprite_rend.color != other.GetComponent<SpriteRenderer>().color)&&(active))
            {
                active = false;
                print("конец игры");
            }
        }
    }
}
