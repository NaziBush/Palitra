using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
    Score score;

	int coins;
	public Text text;

    int lines_passed;


	void Start () 
	{
		text = GetComponent<Text> ();
        coins = 0;
        lines_passed = 0;
		//text.text = score.ToString ();
	}
	
	void OnEnable()
    {
        EventManager.StartListening("LinePassed", LinePassed);
    }

    void OnDisable()
    {
        EventManager.StopListening("LinePassed", LinePassed);
    }

    void LinePassed()
    {
        lines_passed++;
        if (lines_passed >= GameController.game_controller.GetLvlData().lines_to_coin)
        {
            lines_passed = 0;
            coins += GameController.game_controller.GetLvlData().coins_reward;
            text.text = coins.ToString();
        }
    }
}
