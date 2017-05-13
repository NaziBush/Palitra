using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ToStartMenu()
    {
        UIController.ui.Game();
        SceneManager.LoadScene("Start_Menu");
        
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

}
