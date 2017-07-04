using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController game_controller;
    enum GameState { MainMenu,Game,Pause};
    GameState game_state;
    [SerializeField]
    LvlData[] lvl_data;
    [SerializeField]
    Sector[] sectors;
    int lvl_number;
    public bool gameIsOver=false;

    //LineProp[] line_prop;

    int lines_passed;

    public int GetCurrentLvl()
    {
        return lvl_number;
    }

    public int GetLinesPassedNumber()
    {
        return lines_passed;
    }

    public void BeginGame()
    {
        lvl_number = 0;
        InitLvl();
        StartCoroutine(BeginGameCoroutine());
    }
    IEnumerator BeginGameCoroutine()
    {
        EventManager.TriggerEvent("BeginGameAnimation");
        yield return new WaitForSeconds(3.0f);
        UIController.ui.Game();
        EventManager.TriggerEvent("BeginGame");
    }
    void Awake()
    {
        game_state = GameState.MainMenu;
        gameIsOver = false;
        game_controller = this;
        
        
        //EventManager.TriggerEvent("ChangeLvl");
    }
    void Start()
    {
        
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
            
            IncreaseLvl();
            EventManager.TriggerEvent("ChangeLvl");
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
        //if (sectors.Length != lvl_data[lvl_number].colors.Length)
        //{
        //    print("число секторов и число цветов не совпадает");
        //    return;
        //}

        //for (int i=0;i<sectors.Length;i++)
        //{
        //    sectors[i].InitSector(lvl_data[lvl_number].colors[i]);
        //}

        for (int i = 0; i < sectors.Length; i++)
        {
            sectors[i].InitSector(SkinManager.skin_manager.GetCurrentSkin().colors[i]);
        }

        //line_prop = new LineProp[2];
        //line_prop[0] = new LineProp();
        //line_prop[1] = new LineChngblData();

    }



    public void GameOver()
    {

        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        gameIsOver = true;
        Ball.ball.Stop();
        yield return new WaitForSeconds(2.0f);
        UIController.ui.Pause();
    }
}
