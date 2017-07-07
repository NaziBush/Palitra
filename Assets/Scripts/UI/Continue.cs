using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

    public void ContinueGame()
    {
        GameController.game_controller.Continue();

    }
}
