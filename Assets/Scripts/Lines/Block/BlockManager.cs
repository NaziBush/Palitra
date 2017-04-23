using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    public int block_count;
    public GameObject block;
    public Transform block_holder;
    public Transform man;
    Block[] block_mas;
    [HideInInspector]
    public float block_size;
    float window_size;
    public static float spawn_point;


    void InitMan(Vector3 man_position)
    {
        float line_height = GetComponent<SpriteRenderer>().sprite.bounds.extents.y * transform.lossyScale.y;
        float man_height = man.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * man.lossyScale.y;
        float man_width= man.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x * man.lossyScale.x;

        float k = line_height / man_height;

        //print(k);
        man.localScale=new Vector3(man.localScale.x*k, man.localScale.y*k, man.localScale.z);
        man.position = new Vector3(man_position.x+man_width,man_position.y,man_position.z);
    }

    void Start()
    {
        window_size = Edges.rightEdge - Edges.leftEdge;
        block_size = window_size / (float)block_count;
        spawn_point = Edges.leftEdge - window_size;
        
        InitBlocks();
    }

    void InitBlocks()
    {
        float offset = -5.0f;
        Vector3 spawn_position;
        GameObject obj;
        Color prev_color=Color.black;
        for (int i=0;i<block_count;i++)
        {
            spawn_position = new Vector3(Edges.leftEdge + block_size/2.0f + block_size * i + offset, transform.position.y);
            //spawn_position = new Vector3(Edges.leftEdge + block_size / 2.0f + block_size * i, transform.position.y);
            obj = (GameObject)Instantiate(block, spawn_position,Quaternion.identity);
            obj.transform.localScale = new Vector3(block_size+0.1f, obj.transform.localScale.y, 1.0f);

            //obj.GetComponent<Block>().SetRandomColor();
            Color color= GameController.game_controller.GetLvlData().colors
            [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
            if (i!=0)
            {
                if (color==prev_color)
                {
                    if(color== GameController.game_controller.GetLvlData().colors[0])
                    {
                        color = GameController.game_controller.GetLvlData().colors[1];
                    }
                    else
                    {
                        color = GameController.game_controller.GetLvlData().colors[0];
                    }
                }
            }
            obj.GetComponent<Block>().SetColor(color);
            //else
            //{

            //}
            prev_color = color;
            obj.transform.SetParent(block_holder);
        }
        //InitMan(new Vector3(Edges.leftEdge+block_size / 2.0f + block_size * (block_count-1), transform.position.y));
        InitMan(new Vector3(Edges.leftEdge + block_size / 2.0f + block_size * (block_count - 1) + offset, transform.position.y));
        spawn_position = new Vector3(Edges.leftEdge-window_size/ 2.0f, transform.position.y, 0.0f);
        obj = (GameObject)Instantiate(block_holder.gameObject, spawn_position, Quaternion.identity,transform);
        block_mas = GetComponentsInChildren<Block>();
        
        man.SetParent(block_holder);
    }

    public List<Color> CheckCollisions()
    {
        List<Color> colors=new List<Color>();
        foreach (Block item in block_mas)
        {
            if (item.CheckIfCollides())
            {
                colors.Add(item.GetColor());
            }
        }

        return colors;
    }

    public void SetRandomColors()
    {
        if (block_mas != null)
            foreach (Block item in block_mas)
        {
            
            item.SetRandomColor();
        }
    }
	
}


