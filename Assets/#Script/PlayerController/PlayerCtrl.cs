using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [ReadOnly]
    public FsmClass<FSM_PLAYER_STATE> m_state = new FsmClass<FSM_PLAYER_STATE>();


    [ReadOnly]
    public FsmClass<FSM_PLAYER_EQUIP> m_equip = new FsmClass<FSM_PLAYER_EQUIP>();





    public PlayerObjectData playerData;
    private PlayerStat m_playerStat { get; set; }

    public Animator m_PlayerAnimator;

    [SerializeField]
    public FSM_PLAYER_STATE curState;

    public GunBase equipWeapone;
    
    


    private void Awake()
    {
        Init();
        m_state.SetState(FSM_PLAYER_STATE.MOVE);


        m_equip.SetState(FSM_PLAYER_EQUIP.RIFLE);


    }

    private void Update()
    {
        m_state.Update();

        m_equip.Update();
    }

    private void SetLogic()
    {
        // 상태 FSM 추가
        m_state.AddFsm(new FsmPlayerDie());
        m_state.AddFsm(new FsmPlayerIdle());
        m_state.AddFsm(new FsmPlayerMove());
        m_state.AddFsm(new FsmPlayerRevive());

        // 장착 Fsm 추가 
        m_equip.AddFsm(new FsmEquipRifle());
        
    }

    public void SetState(FSM_PLAYER_STATE state)
    {
        m_state.SetState(state);
    }

    // Gunbase 검사
    public GunBase CheckToEquip()
    {
        if(equipWeapone != null)
        {
            return equipWeapone;
        }
        return null;
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

