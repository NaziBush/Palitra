using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ToMainMenu : MonoBehaviour
{

    public void ToMainMenu()
    {
        GameController.game_controller.ToMainMenu();
    }
}
