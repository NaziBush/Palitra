using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{

    

    public void PauseGame()
    {
        print("pause");
        GameController.game_controller.Pause();
        
    }
}
