using UnityEngine;
using System.Collections;

public class Part : MonoBehaviour
{
    SpriteRenderer sprite_rend;

    void Awake()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
    }

    public Color GetColor()
    {
        return sprite_rend.color;
    }

    public void SetRandomColor()
    {
        if (sprite_rend != null)
        {
            sprite_rend.color = GameController.game_controller.GetLvlData().colors
                [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
        }
    }
}
