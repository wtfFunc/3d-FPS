using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FsmPlayerRevive : FsmState<FSM_PLAYER_STATE>
{

    public FsmPlayerRevive() : base(FSM_PLAYER_STATE.REVIVE)
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
