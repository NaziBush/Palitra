using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    Transform tran;
    float speed;

    void Start()
    {
        tran = GetComponent<Transform>();
        speed = GameController.game_controller.GetLvlData().min_speed;
    }

    void Update()
    {
        tran.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void IncreaseSpeed(float acceleration)
    {
        speed += acceleration;
        if (speed > GameController.game_controller.GetLvlData().max_speed)
            speed = GameController.game_controller.GetLvlData().max_speed;
    }
}
