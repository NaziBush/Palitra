using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController ui;
    //enum UI_State { Game, Pause, Skin, Count };
    //UI_State state;
    public GameObject pause_menu;
    //public GameObject skin_menu;
    public Text current_lvl;
    static bool is_paused;
    static float saved_time_scale=1.0f;
    public GameObject SkinMenu;
    public GameObject StartMenu;
    public GameObject Game_UI;
    public GameObject Game_triangle;
    public GameObject UI_triangle;

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

        pause_menu.SetActive(true);
       // skin_menu.SetActive(false);
    }

    public void Game()
    {
        SkinMenu.SetActive(false);
        StartMenu.SetActive(false);
        pause_menu.SetActive(false);
        Game_UI.SetActive(true);
        UI_triangle.GetComponent<RectTransform>().SetParent(Game_UI.transform);
        //Game_triangle.transform.position = UI_triangle.transform.position;
        //Game_triangle.transform.rotation = UI_triangle.transform.rotation;
        //Game_triangle.transform.localScale = UI_triangle.transform.localScale;

        Time.timeScale = saved_time_scale;

        is_paused = false;
        if (GameController.game_controller.gameIsOver)
        {
            SceneManager.LoadScene("Main");
        }
    }


    public void OpenSkinMenu()
    {
        //SceneManager.LoadScene("Main");
        SkinMenu.SetActive(true);
        StartMenu.SetActive(false);

    }

    //public void Skin()
    //{
    //    Time.timeScale = 0.0f;
    //    is_paused = true;
    //    current_lvl.text = GameController.game_controller.GetCurrentLvl().ToString();

    //    pause_menu.SetActive(false);
    //    skin_menu.SetActive(true);
    //}


}
