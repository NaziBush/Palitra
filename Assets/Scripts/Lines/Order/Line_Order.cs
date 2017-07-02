﻿using UnityEngine;
using System.Collections;

public class Line_Order : Line
{
    BlockManager_Order block_manager;
    bool crossed = false;
    public int line_spawn_number;
    public float prev_edge;
    public bool finished = false;

    public override void InitLine()
    {
        
        block_manager = GetComponent<BlockManager_Order>();
        base.InitLine();
        line_spawn_number = SpawnWaves.spawn.GetLineSpawnedNumber();
        crossed = false;
        finished = false;
        prev_edge = SpawnWaves.spawn.prev_edge;
    }

    void Start()
    {
        
        
    }

    protected override void CheckIfPassed()
    {
        //событие LinePassed вызывается в BlockManager
        if (!finished)
        {
            Ball.ball.LinePassed(Color.black);
        }
        else
        {
            anim.BeginAnimation();
            active = false;
            Ball.ball.LinePassed(Ball.ball.GetColor());
        }
        
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
        //if ((active) && (GameController.game_controller.GetLinesPassedNumber() == line_spawn_number - 1) && (!crossed))
        //{
        //    BallMove.ball_move.SlowDown(deceleration);
        //    crossed = true;
        //}
        if ((active) && (Ball.ball.GetPosition().y > prev_edge) && (!crossed))
        {
            BallMove.ball_move.SlowDown(deceleration);
            EventManager.TriggerEvent("BallColorChanged");
            crossed = true;
        }
    }

    public override void ChangeColor()
    {
        //StartCoroutine(block_manager.SetRandomColors());
        block_manager.InitBlocks();
    }
}
