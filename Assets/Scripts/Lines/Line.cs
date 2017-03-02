using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{
    SpriteRenderer sprite_rend;
    protected Color line_color;
    protected float height;
    protected Transform tran;
    protected bool active;

    void Awake()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        tran = GetComponent<Transform>();
        height = sprite_rend.sprite.bounds.extents.y;
    }

    void OnEnable()
    {
        active = true;
        Color[] colors = GameController.game_controller.GetLvlData().colors;
        ChangeColor(colors[Random.Range(0, colors.Length)]);
        
    }

    public void ChangeColor(Color new_color)
    {
        line_color = new_color;
        sprite_rend.color = new_color;
    }

    void Update()
    {
        CheckIfPassed();
    }

    protected virtual void CheckIfPassed()
    {
        if ((active) && (tran.position.y - height < Ball.ball.tran.position.y))
        {
            Ball.ball.LinePassed(line_color);
            active = false;
        }
    }



    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Ball"))
    //    {
    //        //if ((sprite_rend.color != other.GetComponent<SpriteRenderer>().color)&&(active))
    //        if (sprite_rend.color != other.GetComponent<SpriteRenderer>().color)
    //        {
    //            //active = false;
    //            GameController.game_controller.GameOver();
    //        }
    //    }
    //}
}
