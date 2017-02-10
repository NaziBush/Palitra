using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    SpriteRenderer sprite_rend;
    Transform tran;

    // Use this for initialization
    void Start ()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
        tran = GetComponent<Transform>();
        
    }
	
    void OnEnable()
    {
        StartCoroutine(SwitchColor());
    }

	IEnumerator SwitchColor()
    {
        yield return new WaitForSeconds(0.2f);
        while (tran.position.y-Ball.ball.gameObject.transform.position.y > SpawnWaves.spawn.dist)
        {
            sprite_rend.color = GameController.game_controller.GetLvlData().colors[Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
            yield return new WaitForSeconds(1.0f);
        }
    }
}
