using UnityEngine;
using System.Collections;

public class Runtime_Closing : MonoBehaviour
{
    //public bool left;
    public Transform tran;//левая часть
    public Transform tran_right;
    float half_width;
    float start_x;
    float start_y;
    float k;
    bool set_start;
    Line_Closing line_close;
    public bool cross_ball;
    bool go_back;

    bool CheckIfCrossBall()
    {
        if (tran.position.x+half_width>-Ball.ball.size_x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Awake()
    {
        line_close = GetComponent<Line_Closing>();
        half_width = (Edges.rightEdge - Edges.leftEdge) / 4.0f;
    }

    void OnEnable()
    {
        go_back = false;
        tran.position = new Vector3(Edges.leftEdge-1.0f, tran.position.y, 0.0f);
        tran_right.position = new Vector3(-tran.position.x, tran.position.y, 0.0f);
        set_start = false;
    }

	void Update ()
    {
        if (tran.position.y - Ball.ball.tran.position.y > tran.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents.y*tran.lossyScale.y)
            return;
        else
        {
            if (!set_start)
                SetStart();
        }
        //float x = (tran.position.y - Ball.ball.tran.position.y) * k;
        float x = (tran.position.y - Ball.ball.tran.position.y) * k;

        x = -x;
        cross_ball = CheckIfCrossBall();
        if (cross_ball)
        {
            go_back = true;
            tran.Translate(Vector2.left * Time.deltaTime);
            tran_right.position = new Vector3(-tran.position.x, tran.position.y, 0.0f);
            return;
        }
        //if (x>tran.position.x)
        tran.position = new Vector3(x-half_width, tran.position.y, 0.0f);
        tran_right.position = new Vector3(-tran.position.x, tran.position.y, 0.0f);

    }

    void SetStart()
    {
        start_y = tran.position.y - Ball.ball.tran.position.y;
        //start_x = tran.position.x ;
        start_x = tran.position.x + half_width;
        k = Mathf.Abs(start_x / start_y);
        set_start = true;
        //line_close.ChangeColor();
    }
}
