using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController game_controller;
    [SerializeField]
    LvlData[] lvl_data;
    int lvl_number;

    
    void Awake()
    {
        game_controller = this;
        lvl_number = 0;
    }

    void IncreaseLvl()
    {
        lvl_number++;
        if (lvl_number < lvl_data.Length)
        {
            print("текущий уровень" + lvl_number);
        }
        else
        {
            print("конец игры");
        }
    }

    public LvlData GetLvlData()
    {
        return lvl_data[lvl_number];
    }

    void InitGame()
    {

    }
}
