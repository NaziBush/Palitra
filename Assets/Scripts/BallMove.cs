using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    Transform tran;

    void Start()
    {
        tran = GetComponent<Transform>();
    }

    void Update()
    {
        tran.Translate(Vector2.up * GameController.game_controller.GetLvlData().min_speed * Time.deltaTime);
    }
}
