using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [ReadOnly]
    public FsmClass<FSM_PLAYER_STATE> m_logic = new FsmClass<FSM_PLAYER_STATE>();


    public PlayerObjectData playerData;
    private PlayerStat m_playerStat { get; set; }

    public Animator m_PlayerAnimator;

    [SerializeField]
    public FSM_PLAYER_STATE curState;

    private void Awake()
    {
        Init();
        m_logic.SetState(FSM_PLAYER_STATE.MOVE);

    }

    private void Update()
    {
        m_logic.Update();
    }

    private void SetLogic()
    {
        m_logic.AddFsm(new FsmPlayerDie());
        m_logic.AddFsm(new FsmPlayerIdle());
        m_logic.AddFsm(new FsmPlayerMove());
        m_logic.AddFsm(new FsmPlayerRevive());

    }

    public void SetState(FSM_PLAYER_STATE state)
    {
        m_logic.SetState(state);
    }

    


    private void Init()
    {
        m_playerStat = new PlayerStat();
        m_playerStat.Hp = playerData.Hp;
        m_playerStat.Sp = playerData.Sp;
        m_playerStat.Speed = playerData.Speed;


        SetLogic();
    }
}

public class PlayerStat
{
    public float Speed = 1f;
    public int Hp = 100;
    public int Sp = 0;
}