using UnityEngine;
//using System;
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
            //if ((Ball.ball.sprite_rend.color == item.GetColor())&&(item.gameObject.activeSelf))
            if ((line.GetTransform().position.y - line.GetHeight() - Ball.ball.tran.position.y < SpawnWaves.spawn.dist)&&
                (Ball.ball.sprite_rend.color == item.GetColor()) && (item.active))
            {
                if (item.Hit())
                {
                    active_block_count--;
                }
                if (active_block_count<=0)
                {
                    //EventManager.TriggerEvent("LinePassed");
                    Ball.ball.LinePassed(Ball.ball.sprite_rend.color);
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


            Color color = SkinManager.skin_manager.GetCurrentSkin().colors
            [Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];

            obj.GetComponent<Multiple_Block>().SetColor(color);
            obj.GetComponent<Multiple_Block>().block_count=block_count;
            obj.transform.SetParent(block_holder);
        }
        block_mas = GetComponentsInChildren<Multiple_Block>();
    }

    public IEnumerator SetRandomColors()
    {
        //print("sfg");
        while (block_mas == null)
        yield return new WaitForEndOfFrame();


        //создаем и заполняем массив цветов
        int color_count = SkinManager.skin_manager.GetCurrentSkin().colors.Length > block_count ?
            SkinManager.skin_manager.GetCurrentSkin().colors.Length : block_count;

            Color[] colors = new Color[color_count];
            for (int i = 0; i < color_count; i++)
            {

                if (i < 3)
                {
                    colors[i] = SkinManager.skin_manager.GetCurrentSkin().colors[i];
                    //Debug.Log(colors[i]);
                }
                else
                {
                    colors[i] = SkinManager.skin_manager.GetCurrentSkin().colors
                        [Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];
                }
            }
            //перемешиваем массив цветов
            new System.Random().Shuffle(colors);
            //присваеваем цвета блокам
            for (int i = 0; i < block_count; i++)
            {
                block_mas[i].SetColor(colors[i]);
            }
        
      
    }

    //public void SetRandomColors()
    //{
    //    //print("sfg");
    //    if (block_mas != null)
    //    {
    //        //создаем и заполняем массив цветов
    //        Color[] colors = new Color[block_count];
    //        for (int i = 0; i < block_count; i++)
    //        {

    //            if (i < 3)
    //            {
    //                colors[i] = SkinManager.skin_manager.GetCurrentSkin().colors[i];
    //                Debug.Log(colors[i]);
    //            }
    //            else
    //            {
    //                colors[i] = SkinManager.skin_manager.GetCurrentSkin().colors
    //                    [Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];
    //            }
    //        }
    //        //перемешиваем массив цветов
    //        new System.Random().Shuffle(colors);
    //        //присваеваем цвета блокам
    //        for (int i = 0; i < block_count; i++)
    //        {
    //            block_mas[i].SetColor(colors[i]);
    //        }
    //    }
    //}
}
