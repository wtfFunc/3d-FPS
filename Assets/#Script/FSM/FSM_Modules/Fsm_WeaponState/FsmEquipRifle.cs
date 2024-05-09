using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmEquipRifle : FsmState<FSM_PLAYER_EQUIP>
{
    // 무기의 에임상태
    private Aiming state = Aiming.None;
    // 정조준으로 넘어가려면 충족해야하는 클릭시간
    private float delTime = 0.0f;
    private float limit = 0.1f;


    bool scopeMode = false;
    bool aimMode = false;

    public FsmEquipRifle() : base(FSM_PLAYER_EQUIP.RIFLE)
    {

    }


    public override void Enter()
    {
        base.Enter();
        // 에임상태를 초기화
        state = Aiming.None;
    }
    public override void Loop()
    {
        base.Loop();

        // 마우스 우클릭
        if (Input.GetKeyDown(KeyCode.Mouse1) )
        {
            if (state == Aiming.None)
            {

                Debug.Log("우클릭 감지");
                return;
            }

        }

        // 우클릭을 바로떼면
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if(aimMode == false)
            {
                if(state != Aiming.Scope)
                {
                    // 스코프 모드
                    state = Aiming.Scope;
                    Scope(true);
                    return;
                }
                else
                {
                    // 스코프 모드
                    Scope(false);
                    return;
                }

            }
            else
            {
                Aim(false);
            }
            
        }

        // 우클릭을 유지하면
        if (Input.GetKey(KeyCode.Mouse1) && state == Aiming.None)
        {

            delTime += Time.deltaTime;
            if(delTime > limit)
            {
                Aim(true);
            }
            return;
        }
        else
        {
            // 입력시간 초기화
            delTime = 0f;
        }
    }
    public override void End()
    {
        base.End();
        // 나가면 초기화
        state = Aiming.None;
    }


    public void Scope(bool pram)
    {
        scopeMode = pram;

        if(pram == false)
        {
            state = Aiming.None;
            Debug.Log("스코프 해제.");
        }
        else
        {
            state = Aiming.Scope;
            Debug.Log("스코프 진입.");
        }
    }

    public void Aim(bool pram)
    {
        aimMode = pram;

        if(pram == false)
        {
            state = Aiming.None;
            Debug.Log("정조준 해제.");
        }
        else
        {
            state = Aiming.Aiming;
            Debug.Log("정조준 진입.");
        }
    }

    public void Shot()
    {

    }

    enum Aiming
    {
        None,
        Scope,
        Aiming,
        Change
    }
}