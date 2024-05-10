using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : GunBase
{
    


    [HideInInspector]
    public float m_Damage;
    [HideInInspector]
    public float m_FireRate;
    [HideInInspector]
    public float m_Speed;
    [HideInInspector]
    public int m_MaxAmmo;

    public Transform m_sightObject;



    private void Awake()
    {
        SetRifle(gunData);
    }

    public override void Equip()
    {

    }

    public override void Fire()
    {
        // 사격 호출매서드
    }

    public override void Drop()
    {

    }

    


    private void SetRifle(GunScriptable data)
    {
        if(data == null)
        {
            Debug.LogError("GunScriptable is Null");
        }

        m_Damage = data.damage;
        m_FireRate = data.fireRate;
        m_Speed = data.ammoSpeed;
        m_MaxAmmo = data.maxAmmo;
    }
}
