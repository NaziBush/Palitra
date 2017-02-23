using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{

	public void SetRandomColor()
    {
        GetComponent<SpriteRenderer>().color = GameController.game_controller.GetLvlData().colors
            [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
    }
}
