using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    public Text current_lvl;
    static bool is_paused;
    static float saved_time_scale=1.0f;

    public GameObject pause_menu;
    public GameObject SkinMenu;
    public GameObject StartMenu;
    public GameObject Game_UI;

    void Awake ()
    {
        is_paused = false;
        ui = this;
        saved_time_scale = Time.timeScale;
        //state = UI_State.Game;
    }
	
	public void Pause()
    {
        Time.timeScale = 0.0f;
        is_paused = true;
        current_lvl.text = GameController.game_controller.GetCurrentLvl().ToString();
        SkinMenu.SetActive(false);
        StartMenu.SetActive(false);
        pause_menu.SetActive(true);
       // skin_menu.SetActive(false);
    }

    public void Game()
    {
        SkinMenu.SetActive(false);
        StartMenu.SetActive(false);
        pause_menu.SetActive(false);
        Game_UI.SetActive(true);

        Time.timeScale = saved_time_scale;

        is_paused = false;

        if (GameController.game_controller.GetState()==GameState.GameOver)
        {

        }
        //if (GameController.game_controller.gameIsOver)
        //{
        //   // SceneManager.LoadScene("New Main");
        //}
    }

    public void OpenSkinMenu()
    {
        //SceneManager.LoadScene("Main");
        SkinMenu.SetActive(true);
        StartMenu.SetActive(false);
    }
}
