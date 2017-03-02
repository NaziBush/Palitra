using UnityEngine;
using System.Collections.Generic;

public class Line_Block : Line
{
    BlockManager block_manager;

    protected override void Start()
    {
        base.Start();
        block_manager = GetComponent<BlockManager>();
    }

    protected override void CheckIfPassed()
    {
        if ((active) && (tran.position.y - height < Ball.ball.tran.position.y))
        {
            List<Color> colors = block_manager.CheckCollisions();
            Ball.ball.LinePassed(colors);
            active = false;
        }
    }
}
