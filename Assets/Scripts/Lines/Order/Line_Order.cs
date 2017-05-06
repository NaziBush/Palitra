using UnityEngine;
using System.Collections;

public class Line_Order : Line
{
    BlockManager_Order block_manager;
    float saved_dist;

    public override void InitLine()
    {
        block_manager = GetComponent<BlockManager_Order>();
        saved_dist = SpawnWaves.spawn.dist;
        base.InitLine();
    }

    protected override void CheckIfPassed()
    {
        //если линия активна, то она в любом случае не проходит
        //событие LinePassed вызывается в BlockManager
        Ball.ball.LinePassed(Color.black);
        
    }

    protected override void CheckIfCrossed()
    {
        base.CheckIfCrossed();

        float deceleration = 0.0f;
        PoolType pool_type = GetComponent<PoolRef>().GetPool().pool_type;
        switch (pool_type)
        {
            case (PoolType.Combo_3_parts):
                deceleration = GameController.game_controller.GetLvlData().combo_prop_3_parts.slowing;
                break;
            case (PoolType.Combo_4_parts):
                deceleration = GameController.game_controller.GetLvlData().combo_prop_4_parts.slowing;
                break;
            case (PoolType.Combo_5_parts):
                deceleration = GameController.game_controller.GetLvlData().combo_prop_5_parts.slowing;
                break;
        }
        if ((active) && (tran.position.y - height - Ball.ball.tran.position.y > saved_dist))
        {
            BallMove.ball_move.SlowDown(deceleration);
        }
    }

    public override void ChangeColor()
    {
        //StartCoroutine(block_manager.SetRandomColors());
        block_manager.InitBlocks();
    }
}
