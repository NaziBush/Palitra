using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    Line line;
    Transform tran;
    [SerializeField]
    float dist;

    // Use this for initialization
    void Start ()
    {
        line = GetComponent<Line>();
        tran = GetComponent<Transform>();
        
    }
	
    void OnEnable()
    {
        StartCoroutine(SwitchColor());
    }

	IEnumerator SwitchColor()
    {
        yield return new WaitForSeconds(0.2f);
        while (tran.position.y-Ball.ball.gameObject.transform.position.y > dist)
        {
            line.ChangeColor(GameController.game_controller.GetLvlData().colors[Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)]);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
