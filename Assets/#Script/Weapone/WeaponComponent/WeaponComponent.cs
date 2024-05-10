using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponComponent : MonoBehaviour, IComponent
{
    public E_WeaponComponent componentType;


    protected UnityAction _useAction;

    protected UnityAction _equipAction;

    protected UnityAction _disuseAction;

    // 파츠 컴포지트에서 호출할 델리게이트 인스턴스
    public IComponent.PartsUse D_Equip;
    public IComponent.PartsUse D_Use;
    public IComponent.PartsUse D_Dispose;

    /// <summary>
    /// 베이스 이니셜라이즈는 항상 마지막줄에 넣어주세요
    /// </summary>
    public virtual void Init()
    {
        D_Equip         = new IComponent.PartsUse(_useAction);
        D_Use           = new IComponent.PartsUse(_equipAction);
        D_Dispose       = new IComponent.PartsUse(_disuseAction);
    }

    public virtual void Equip()
    {

    }

    public virtual void Use()
    {

    }

    public virtual void Dispose()
    {

    }

    public void Display(int depth)
    {
        // 컴포넌트형식으로써 공통된 매서드

    }

    E_WeaponComponent IComponent.GetType()
    {
        return componentType;
    }
}
public enum E_WeaponComponent
{
    scope,
    magazine,
    handle,
    muzzle
}