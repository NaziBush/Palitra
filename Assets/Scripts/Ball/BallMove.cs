using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
	public static BallMove ball_move;
    bool slowed = false;
    bool resuming = false;
    enum State { normal,slowed,resuming};
    State current_state=State.normal;
    Transform tran;
    float speed;
    float saved_speed=1.0f;
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
            if (!slowed)
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
        if (slowed)
            return;
        Speed += acceleration;
        //print(Speed);
    }

    public void SlowDown(float deceleration)
    {
        if (slowed)
        {
            StopCoroutine(coroutine);
            resuming = false;
            //Speed = saved_speed;
        }
        coroutine = SlowDownCoroutine(deceleration);
        StartCoroutine(coroutine);
    }

	public bool CheckIfSlowed()
	{
		return slowed;
	}

    IEnumerator SlowDownCoroutine(float deceleration)
    {
        if (!slowed)
            saved_speed = Speed;
        else
        {
            Speed = saved_speed;
        }
        float x = (Speed - deceleration) / 5.0f;
        Speed = deceleration;
        slowed = true;
        
        while ((slowed)&&(!resuming))
        {
            yield return new WaitForSeconds(0.1f);
        }
        
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
        slowed = false;
        resuming = false;
    }

    public void ResumeSpeed()
    {
        resuming = true;
    }


}
