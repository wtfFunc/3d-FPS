using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : WeaponComponent
{
    public Camera scopeCam;

    public float time;

    

    public Scope(E_PartsType e_WeaponComponent)
    {
        componentType = e_WeaponComponent;
    }


    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        _useAction      = Use;
        _disuseAction   = Dispose;
        _equipAction    = Equip;


        base.Init();
    }

    public override void Equip()
    {
        base.Equip();
    }

    public override void Use()
    {
        Camera.main.enabled = false;
        scopeCam.enabled = true;

        scopeCam.fieldOfView = time;
        base.Use();
    }

    public override void Dispose()
    {
        Camera.main.enabled = true;
        scopeCam.enabled = false;

        base.Dispose();
    }
}
