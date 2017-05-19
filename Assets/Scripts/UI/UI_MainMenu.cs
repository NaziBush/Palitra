using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject SkinMenu;
    public GameObject StartMenu;
    //public Image BG;

    public void OpenSkinMenu()
    {
        //SceneManager.LoadScene("Main");
        SkinMenu.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void OpenStartMenu()
    {
        SkinMenu.SetActive(false);
        StartMenu.SetActive(true);
        
    }
}
