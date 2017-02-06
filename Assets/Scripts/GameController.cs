using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController game_controller;
    [SerializeField]
    LvlData[] lvl_data;
    [SerializeField]
    Sector[] sectors;
    int lvl_number;

    
    void Awake()
    {
        game_controller = this;
        
    }
    void Start()
    {
        lvl_number = 0;
        InitLvl();
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

    void InitLvl()
    {
        if (sectors.Length != lvl_data[lvl_number].colors.Length)
        {
            print("число секторов и число цветов не совпадает");
            return;
        }

        for (int i=0;i<sectors.Length;i++)
        {
            sectors[i].InitSector(lvl_data[lvl_number].colors[i]);
        }
    }
}
