using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scope : WeaponComponent
{
    public Camera scopeCam;

    public float time;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        _ComponentAction = ScopeAction;
        _DisuseAction = UnScopeAction;
        _EquipAction = Equip;
    }

    public override void Equip()
    {
        base.Equip();
    }

    public override void Use()
    {
        base.Use();
        
    }

    public override void disuse()
    {
        base.disuse();

    }


    private void ScopeAction()
    {
        Camera.main.enabled = false;
        scopeCam.enabled = true;

        scopeCam.fieldOfView = time;
    }

    private void UnScopeAction()
    {
        Camera.main.enabled = true;
        scopeCam.enabled = false;

        // scopeCam.fieldOfView = 1f;
    }
}
