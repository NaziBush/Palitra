using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController game_controller;
    LvlData[] lvl_data;
    public LvlData active_lvl_data;
    int lvl_number;

    
    void Awake()
    {
        game_controller = this;
        lvl_number = 0;
    }

    void IncreaseLvl()
    {
        lvl_number++;
        if (lvl_number<lvl_data.Length)
            active_lvl_data = lvl_data[lvl_number];
        else
        {
            print("конец игры");
        }
    }
}
