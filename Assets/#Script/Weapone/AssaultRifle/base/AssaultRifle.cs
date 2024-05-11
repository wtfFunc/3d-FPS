using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : GunBase
{
    


    [HideInInspector]
    public float m_Damage; // 대미지
    [HideInInspector]
    public float m_FireRate; // 연사속도
    [HideInInspector]
    public float m_Speed; // 탄속
    [HideInInspector]
    public float m_Weight; // 탄낙
    [HideInInspector]
    public int m_MaxAmmo; 

    public Transform m_sightObject;



    private void Awake()
    {
        SetRifle(gunData);
        lineRenderer = GetComponent<LineRenderer>();
        DrawCurve();
    }

    public override void Equip()
    {

    }

    public override void Use()
    {
        // 사격 호출매서드
    }

    public override void Dispose()
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
