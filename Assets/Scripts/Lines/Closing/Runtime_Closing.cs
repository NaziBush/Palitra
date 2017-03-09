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

    void Awake()
    {
        half_width = (Edges.rightEdge - Edges.leftEdge) / 4.0f;
    }

    void OnEnable()
    {
        tran.position = new Vector3(Edges.leftEdge, tran.position.y, 0.0f);
        start_y = tran.position.y - Ball.ball.tran.position.y;
        start_x = tran.position.x ;
        k = Mathf.Abs(start_x / start_y);
        tran_right.position = new Vector3(-tran.position.x, tran.position.y, 0.0f);
    }

	void Update ()
    {
        //float x = -(tran.position.y - Ball.ball.tran.position.y + half_width);
        //float x = Mathf.Lerp(tran.position.x,-half_width,0.1f);
        float x = (tran.position.y - Ball.ball.tran.position.y) * k;
        if (x < 0.01f)
            return;
        x += half_width;
        x = -x;
        //if (x>tran.position.x)
        tran.position = new Vector3(x, tran.position.y, 0.0f);
        tran_right.position = new Vector3(-tran.position.x, tran.position.y, 0.0f);
    }
}
