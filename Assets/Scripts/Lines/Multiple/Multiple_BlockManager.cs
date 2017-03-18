using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Multiple_BlockManager : MonoBehaviour
{
    public int block_count;
    public GameObject block;
    public Transform block_holder;
    Multiple_Block[] block_mas;
    Line_Multiple line;
    float block_size;
    float window_size;
    int active_block_count;
    //int current_block;

    void Start()
    {
        window_size = Edges.rightEdge - Edges.leftEdge;
        block_size = window_size / (float)block_count;
        line = GetComponent<Line_Multiple>();
        InitBlocks();
    }

    void OnEnable()
    {
        active_block_count = block_count;
        EventManager.StartListening("BallColorChanged", ColorChanged);
        //current_block = 0;
    }
    void OnDisable()
    {
        EventManager.StopListening("BallColorChanged", ColorChanged);
    }
    void ColorChanged()
    {
        //if (current_block<block_mas.Length)
        //{
        //    if (Ball.ball.sprite_rend.color == block_mas[current_block].GetColor())
        //    {
        //        block_mas[current_block].Hit();
        //        current_block++;
        //        if (current_block >= block_mas.Length)
        //        {
        //            line.Disable();
        //        }
        //    }
        //}

        foreach (Multiple_Block item in block_mas)
        {
            if ((Ball.ball.sprite_rend.color == item.GetColor())&&(item.gameObject.activeSelf))
            {
                if (item.Hit())
                {
                    active_block_count--;
                }
                if (active_block_count<=0)
                {
                    line.Disable();
                }
            }
        }
    }
    void InitBlocks()
    {
        Vector3 spawn_position;
        GameObject obj;
        
        for (int i = 0; i < block_count; i++)
        {
            spawn_position = new Vector3(Edges.leftEdge + block_size / 2.0f + block_size * i, transform.position.y);
            obj = (GameObject)Instantiate(block, spawn_position, Quaternion.identity);
            obj.transform.localScale = new Vector3(block_size + 0.1f, obj.transform.localScale.y, 1.0f);
            Color color = GameController.game_controller.GetLvlData().colors
            [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
            obj.GetComponent<Multiple_Block>().SetColor(color);
            obj.transform.SetParent(block_holder);
        }
        block_mas = GetComponentsInChildren<Multiple_Block>();
    }

    public void SetRandomColors()
    {
       
        if (block_mas != null)
            foreach (Multiple_Block item in block_mas)
            {
                Color color = GameController.game_controller.GetLvlData().colors
           [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
                item.SetColor(color);
            }
    }
}
