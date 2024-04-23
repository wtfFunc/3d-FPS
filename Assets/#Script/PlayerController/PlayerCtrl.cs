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


    [SerializeField]
    public FSM_UI_STATE curState;

    private void Awake()
    {
        
        m_logic.SetState(FSM_PLAYER_STATE.IDLE);
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

    public class PlayerStat
    {
        public float Speed = 1f;
        public int Hp = 100;
        public int Sp = 0;
    }


    private void Init()
    {
        m_playerStat.Hp = playerData.Hp;
        m_playerStat.Sp = playerData.Sp;
        m_playerStat.Speed = playerData.Speed;


        SetLogic();
    }
}