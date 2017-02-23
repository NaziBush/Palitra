using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour
{
    public int block_count;
    public GameObject block;
    public Transform block_holder;
    float block_size;
    float window_size;
    public static float spawn_point;

    void Start()
    {
        window_size = Edges.rightEdge - Edges.leftEdge;
        block_size = window_size / (float)block_count;
        spawn_point = Edges.leftEdge - window_size;
        InitBlocks();
    }

    void InitBlocks()
    {
        Vector3 spawn_position;
        GameObject obj;
        for (int i=0;i<block_count;i++)
        {
            spawn_position = new Vector3(Edges.leftEdge + block_size/2.0f + block_size * i, transform.position.y);
            obj = (GameObject)Instantiate(block, spawn_position,Quaternion.identity);
            obj.transform.localScale = new Vector3(block_size+0.1f, 1.0f, 1.0f);
            obj.GetComponent<Block>().SetRandomColor();
            obj.transform.SetParent(block_holder);
        }
        spawn_position = new Vector3(Edges.leftEdge-window_size/2.0f, transform.position.y, 0.0f);
        obj = (GameObject)Instantiate(block_holder.gameObject, spawn_position, Quaternion.identity,transform);
    }
	
}


