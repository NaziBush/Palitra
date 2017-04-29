using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
	public static BallMove ball_move;
	bool slowed;
    Transform tran;
    float speed;

	void Awake()
	{
		ball_move=this;
	}
    void Start()
    {
        tran = GetComponent<Transform>();
        speed = GameController.game_controller.GetLvlData().min_speed;
    }
    float Speed
    {
        get
        {
            return speed;
        }
        set
        {
			speed = Mathf.Clamp (value, GameController.game_controller.GetLvlData ().min_speed, GameController.game_controller.GetLvlData ().max_speed);
        }
    }
    void Update()
    {
        tran.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void IncreaseSpeed(float acceleration)
    {
        Speed += acceleration;
        //print(Speed);
    }

    public void SlowDown(float deceleration)
    {
        StartCoroutine(SlowDownCoroutine(deceleration));
    }

	public bool CheckIfSlowed()
	{
		return slowed;
	}

    IEnumerator SlowDownCoroutine(float deceleration)
    {
        Speed -= deceleration;
        slowed = true;
        yield return new WaitForSeconds(1.0f);
		Speed += deceleration;
        slowed = false;
    }
}
