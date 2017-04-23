using UnityEngine;
using System.Collections;

public class Line_Order : Line
{
    BlockManager_Order block_manager;

    protected override void InitLine()
    {
        block_manager = GetComponent<BlockManager_Order>();
    }

    protected override void CheckIfPassed()
    {
        //если линия активна, то она в любом случае не проходит
        //событие LinePassed вызывается в BlockManager
        Ball.ball.LinePassed(Color.black);
        
    }

    public override void ChangeColor()
    {
        StartCoroutine(block_manager.SetRandomColors());
    }
}
