using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmEquipRifle : FsmState<PLAYER_EQUIP>
{

    public FsmEquipRifle() : base(PLAYER_EQUIP.RIFLE)
    {

    }


    public override void Enter()
    {

        base.Enter();
    }
    public override void Loop()
    {
        // ���콺 ��Ŭ��
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
        base.Loop();
    }
    public override void End()
    {
        base.End();
    }
}