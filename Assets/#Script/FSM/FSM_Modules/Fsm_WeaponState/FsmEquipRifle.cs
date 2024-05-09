using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmEquipRifle : FsmState<FSM_PLAYER_EQUIP>
{
    // ������ ���ӻ���
    private Aiming state = Aiming.None;
    // ���������� �Ѿ���� �����ؾ��ϴ� Ŭ���ð�
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
        // ���ӻ��¸� �ʱ�ȭ
        state = Aiming.None;
    }
    public override void Loop()
    {
        base.Loop();

        // ���콺 ��Ŭ��
        if (Input.GetKeyDown(KeyCode.Mouse1) )
        {
            if (state == Aiming.None)
            {

                Debug.Log("��Ŭ�� ����");
                return;
            }

        }

        // ��Ŭ���� �ٷζ���
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if(aimMode == false)
            {
                if(state != Aiming.Scope)
                {
                    // ������ ���
                    state = Aiming.Scope;
                    Scope(true);
                    return;
                }
                else
                {
                    // ������ ���
                    Scope(false);
                    return;
                }

            }
            else
            {
                Aim(false);
            }
            
        }

        // ��Ŭ���� �����ϸ�
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
            // �Է½ð� �ʱ�ȭ
            delTime = 0f;
        }
    }
    public override void End()
    {
        base.End();
        // ������ �ʱ�ȭ
        state = Aiming.None;
    }


    public void Scope(bool pram)
    {
        scopeMode = pram;

        if(pram == false)
        {
            state = Aiming.None;
            Debug.Log("������ ����.");
        }
        else
        {
            state = Aiming.Scope;
            Debug.Log("������ ����.");
        }
    }

    public void Aim(bool pram)
    {
        aimMode = pram;

        if(pram == false)
        {
            state = Aiming.None;
            Debug.Log("������ ����.");
        }
        else
        {
            state = Aiming.Aiming;
            Debug.Log("������ ����.");
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