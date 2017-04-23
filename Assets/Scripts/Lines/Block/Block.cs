using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    //Line line;

    public bool collides;
    BlockManager block_manager;
    static float collision_dist = 0.75f;

    void Start()
    {
        block_manager = GetComponentInParent<BlockManager>();
    }
	public void SetRandomColor()
    {
        GetComponent<SpriteRenderer>().color = GameController.game_controller.GetLvlData().colors
            [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
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
        dist = Mathf.Abs(Mathf.Abs(transform.position.x) - block_manager.block_size / 2.0f);
        //Debug.DrawLine(new Vector3((transform.position.x) - block_manager.block_size/2.0f, transform.position.y, 0.0f),
        //    new Vector3((transform.position.x) - block_manager.block_size/2.0f, transform.position.y-1.0f,0.0f));
        if (dist < collision_dist)
            return true;
        else
            return false;
        
    }
}
