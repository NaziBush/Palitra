using UnityEngine;
using System.Collections.Generic;
using System;

public class Line_Block : Line
{
    BlockManager block_manager;

    public override void InitLine()
    {
        active = true;
        block_manager = GetComponent<BlockManager>();
        block_manager.InitBlocks();
        //tran.position = tran.position - new Vector3(5.0f, 0.0f, 0.0f);
    }

    protected override void CheckIfPassed()
    {
        if ((active) && (tran.position.y - height <= Ball.ball.collision_point.position.y))
        {
            List<Color> colors = block_manager.CheckCollisions();
            Ball.ball.LinePassed(colors,false);
        }
    }

    public override void ChangeColor()
    {
        block_manager.SetRandomColors();
    }
}
