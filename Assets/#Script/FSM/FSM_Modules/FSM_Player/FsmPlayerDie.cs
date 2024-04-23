using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FsmPlayerDie : FsmState<FSM_PLAYER_STATE>
{

    public FsmPlayerDie() : base(FSM_PLAYER_STATE.DIE)
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
