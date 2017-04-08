using UnityEngine;
using System.Collections;

public class Line_Multiple : Line
{

    Multiple_BlockManager block_manager;

    protected override void InitLine()
    {
        block_manager = GetComponent<Multiple_BlockManager>();
    }

    protected override void CheckIfPassed()
    {
        //if ((active) && (tran.position.y - height < Ball.ball.tran.position.y))
        //{
        //если линия активна, то не проходит
        //событие LinePassed вызывается в BlockManager
            Ball.ball.LinePassed(Color.black);
        //}
    }

    public override void ChangeColor()
    {
        StartCoroutine(block_manager.SetRandomColors());
    }
}
