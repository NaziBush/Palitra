using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour
{

	public void BeginGame()
    {
        SceneManager.LoadScene("Main");
        RectTransform tran = GetComponent<RectTransform>();
        //tran.
    }
}
