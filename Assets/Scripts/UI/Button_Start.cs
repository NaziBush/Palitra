using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour
{

	public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
