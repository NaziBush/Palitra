﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    public Text current_lvl;
    static bool is_paused;
    //static float saved_time_scale=1.0f;

    public GameObject pause_menu;
    public GameObject skin_menu;
    public GameObject start_menu;
    public GameObject Game_UI;
    public GameObject round;
    public GameObject triangle_fon;
    public GameObject triangle;

    void Awake ()
    {
        is_paused = false;
        ui = this;
    }
	
    public void UpdateUI()
    {
        switch(GameController.game_controller.GetState())
        {
            case GameState.MainMenu:
                SkinManager.skin_manager.LoadSavedSkin();
                Game_UI.SetActive(false);
                skin_menu.SetActive(false);
                start_menu.SetActive(true);
                pause_menu.SetActive(false);
                round.SetActive(true);
                triangle.SetActive(true);
                triangle_fon.SetActive(true);
                break;

            case GameState.SkinMenu:
                Game_UI.SetActive(false);
                skin_menu.SetActive(true);
                start_menu.SetActive(false);
                pause_menu.SetActive(false);
                round.SetActive(false);
                triangle.SetActive(false);
                triangle_fon.SetActive(false);
                break;

            case GameState.Game:
                Game_UI.SetActive(true);
                skin_menu.SetActive(false);
                start_menu.SetActive(false);
                pause_menu.SetActive(false);
                round.SetActive(true);
                triangle.SetActive(true);
                triangle_fon.SetActive(false);
                break;

            case GameState.Pause:
                Game_UI.SetActive(true);
                skin_menu.SetActive(false);
                start_menu.SetActive(false);
                pause_menu.SetActive(true);
                round.SetActive(false);
                triangle.SetActive(false);
                triangle_fon.SetActive(false);
                current_lvl.text = GameController.game_controller.GetCurrentLvl().ToString();
                break;

            case GameState.GameOver:
                Game_UI.SetActive(true);
                skin_menu.SetActive(false);
                start_menu.SetActive(false);
                pause_menu.SetActive(true);
                round.SetActive(false);
                triangle.SetActive(false);
                triangle_fon.SetActive(false);
                break;
        }
    }

    //public void Game()
    //{
    //    SkinMenu.SetActive(false);
    //    StartMenu.SetActive(false);
    //    pause_menu.SetActive(false);
    //    Game_UI.SetActive(true);

    //    Time.timeScale = saved_time_scale;

    //    is_paused = false;

    //    if (GameController.game_controller.GetState()==GameState.GameOver)
    //    {

    //    }
    //    //if (GameController.game_controller.gameIsOver)
    //    //{
    //    //   // SceneManager.LoadScene("New Main");
    //    //}
    //}

    //public void OpenSkinMenu()
    //{
    //    //SceneManager.LoadScene("Main");
    //    SkinMenu.SetActive(true);
    //    StartMenu.SetActive(false);
    //}
}
