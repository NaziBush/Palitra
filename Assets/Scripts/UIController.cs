using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    //enum UI_State { Game, Pause, Skin, Count };
    //UI_State state;
    public GameObject pause_menu;
    public Text current_lvl;
    static bool is_paused;
    static float saved_time_scale;

    void Awake ()
    {
        is_paused = false;
        ui = this;
        //state = UI_State.Game;
	}
	
	public void Pause()
    {
        saved_time_scale = Time.timeScale;
        Time.timeScale = 0.0f;
        is_paused = true;
        current_lvl.text = GameController.game_controller.GetCurrentLvl().ToString();
        pause_menu.SetActive(true);
    }

    public void Game()
    {
        pause_menu.SetActive(false);
        Time.timeScale = saved_time_scale;
        is_paused = false;
    }

    
}
