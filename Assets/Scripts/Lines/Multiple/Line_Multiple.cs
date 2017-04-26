using UnityEngine;
using System.Collections;

public class Line_Multiple : Line
{
    Multiple_BlockManager block_manager;

    public override void InitLine()
    {
        block_manager = GetComponent<Multiple_BlockManager>();
    }

	protected override void CheckIfCrossed ()
	{
		base.CheckIfCrossed ();
        PoolType pool_type = GetComponent<PoolRef>().GetPool().pool_type;
        float deceleration=0.0f;
        switch (pool_type)
        {
            case (PoolType.Multiple_1_part):
                deceleration = GameController.game_controller.GetLvlData().multiple_prop_1_part.slowing;
                break;
            case (PoolType.Multiple_2_parts):
                deceleration = GameController.game_controller.GetLvlData().multiple_prop_2_parts.slowing;
                break;
            case (PoolType.Multiple_3_parts):
                deceleration = GameController.game_controller.GetLvlData().multiple_prop_3_parts.slowing;
                break;
        }
        
		if ((active) && (tran.position.y - height < 
            Ball.ball.tran.position.y+1))
        {
            BallMove.ball_move.SlowDown(deceleration);
        }

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
