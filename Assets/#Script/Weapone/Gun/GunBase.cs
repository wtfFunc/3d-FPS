using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public abstract class GunBase : MonoBehaviour, IComponent
{
    public GunScriptable gunData;



    public delegate void GunFire();

    public GunFire del;


    [Header("Resource")]
    public AudioSource fireSound;
    public AudioSource reLoadingSound;


    [Header("PartsObject")]
    public Transform camPos;


    public abstract void Equip();

    public abstract void Fire();

    public abstract void Drop();

    public void Display(int depth)
    {

    }

    public void Compositer()
    {
        // 복합 객체 생성
        Composite root = new Composite("Root");

        // 복합 객체에 개별 객체와 다른 복합 객체 추가
        root.Add(new WeaponComponent());
        root.Add(new WeaponComponent());

        Composite composite = new Composite("Composite X");
        composite.Add(new Scope(E_WeaponComponent.scope));
        composite.Add(new WeaponComponent());

        root.Add(composite);

        // 트리 구조 출력
        root.Display(0);
    }

    E_WeaponComponent IComponent.GetType()
    {
        throw new System.NotImplementedException();
    }
}

public enum RIFLE_TYPE
{
    AR,
    SR,
    DMR
}
