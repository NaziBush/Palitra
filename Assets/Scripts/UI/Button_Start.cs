﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour
{

	public void BeginGame()
    {
        //UIController.ui.BeginGame();
        SoundManager.sound_manager.SingleSound(SoundSample.Start);
        GameController.game_controller.BeginGame();
        
        //SceneManager.LoadScene("Main");
        
    }

   

}
