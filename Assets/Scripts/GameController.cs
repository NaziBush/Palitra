using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController game_controller;
    [SerializeField]
    LvlData[] lvl_data;
    [SerializeField]
    Sector[] sectors;
    int lvl_number;

    int lines_passed;

    public int GetCurrentLvl()
    {
        return lvl_number;
    }

    void Awake()
    {
        
        game_controller = this;
    }
    void Start()
    {
        lvl_number = 0;
        InitLvl();
    }

    void OnEnable()
    {
        EventManager.StartListening("LinePassed", LinePassed);
    }

    void OnDisable()
    {
        EventManager.StopListening("LinePassed", LinePassed);
    }

    void LinePassed()
    {
        lines_passed++;
        if (lines_passed >= GameController.game_controller.GetLvlData().lines_to_chng_lvl)
        {
            EventManager.TriggerEvent("ChangeLvl");
            IncreaseLvl();
        }
    }

    void IncreaseLvl()
    {
        lvl_number++;
        if (lvl_number < lvl_data.Length)
        {
            print("текущий уровень" + lvl_number);
            InitLvl();
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
        lines_passed = 0;
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



    public void GameOver()
    {
        SceneManager.LoadScene("Main");
    }
}
