using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    //public Scene scene;
	// Use this for initialization
	void Start ()
    {
        //SceneManager.LoadScene("Start_Menu");
        //SceneManager.LoadScene(scene.buildIndex);
        SceneManager.LoadScene("New Main");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
