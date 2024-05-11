using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : GunBase
{
    


    [HideInInspector]
    public float m_Damage; // �����
    [HideInInspector]
    public float m_FireRate; // ����ӵ�
    [HideInInspector]
    public float m_Speed; // ź��
    [HideInInspector]
    public float m_Weight; // ź��
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
        // ��� ȣ��ż���
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
