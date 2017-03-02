using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    //Line line;

    public bool collides;

    static float collision_dist = 0.75f;

    void Start()
    {

    }
	public void SetRandomColor()
    {
        GetComponent<SpriteRenderer>().color = GameController.game_controller.GetLvlData().colors
            [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
    }

    void Update()
    {
        collides = CheckIfCollides();
    }

    public Color GetColor()
    {
        return GetComponent<SpriteRenderer>().color;
    }

    public bool CheckIfCollides()
    {
        float dist;
        dist = Mathf.Abs(Mathf.Abs(transform.position.x) - transform.localScale.x);
        if (dist < collision_dist)
            return true;
        else
            return false;
        
    }
}
