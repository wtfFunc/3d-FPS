using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponComponent : MonoBehaviour
{
    private UnityAction componentAction;
    protected UnityAction _ComponentAction { get => componentAction; set => componentAction = value; }


    private UnityAction equipAction;
    protected UnityAction _EquipAction { get => equipAction; set => equipAction = value; }


    private UnityAction disuseAction;
    protected UnityAction _DisuseAction { get => disuseAction; set => disuseAction = value; }

    public virtual void Init()
    {

    }

    public virtual void Equip()
    {
        _EquipAction.Invoke();
    }

    public virtual void Use()
    {
        _ComponentAction.Invoke();
    }

    public virtual void disuse()
    {
        _DisuseAction.Invoke();
    }
}
