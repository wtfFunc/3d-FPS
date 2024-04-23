using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FsmPlayerIdle : FsmState<FSM_PLAYER_STATE>
{

    public FsmPlayerIdle() : base(FSM_PLAYER_STATE.IDLE)
    {

    }


    public override void Enter()
    {

        base.Enter();

    }
    public override void Loop()
    {

        base.Loop();
    }
    public override void End()
    {
        base.End();
    }
}