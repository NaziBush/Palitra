using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
	public static BallMove ball_move;
    public enum State { normal,slowed,resuming};
    State current_state=State.normal;
    Transform tran;
    float speed=1.0f;
    float saved_speed=1.0f;
    float x = 0.2f;
    private IEnumerator coroutine;

    void Awake()
	{
		ball_move=this;
	}
    void Start()
    {
        tran = GetComponent<Transform>();
        speed = GameController.game_controller.GetLvlData().min_speed;
        current_state = State.normal;
    }
    float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (current_state==State.normal)
                speed = Mathf.Clamp (value, GameController.game_controller.GetLvlData ().min_speed, GameController.game_controller.GetLvlData ().max_speed);
            else
                speed = Mathf.Clamp(value, 0.1f, GameController.game_controller.GetLvlData().max_speed);
        }
    }
    void Update()
    {
        tran.Translate(Vector2.up * speed * Time.deltaTime);
        //print(speed);
    }

    public void IncreaseSpeed(float acceleration)
    {
        if (current_state != State.normal)
            return;
        Speed += acceleration;
        //print(Speed);
    }

    public void SlowDown(float deceleration)
    {
        //if (slowed)
        //{
        //    StopCoroutine(coroutine);
        //    resuming = false;
        //    //Speed = saved_speed;
        //}
        if (current_state!=State.normal)
        {
            StopAllCoroutines();
            Speed = saved_speed;
        }

        {
            current_state = State.slowed;
            x = (Speed - deceleration) / 5.0f;
            saved_speed = Speed;
            Speed = deceleration;
        }
        
        
        
    }

	public State CheckState()
	{
		return current_state;
	}

    IEnumerator SlowDownCoroutine(float x)
    {
        for (int i=0;i<5;i++)
        {
            if (Speed+x>=saved_speed)
            {
                Speed = saved_speed;
                break;
            }
            Speed += x;
            yield return new WaitForSeconds(1.0f);
        }
        current_state = State.normal;
    }

    public void ResumeSpeed()
    {
        current_state = State.resuming;
        coroutine = SlowDownCoroutine(x);
        StartCoroutine(coroutine);
    }


}
