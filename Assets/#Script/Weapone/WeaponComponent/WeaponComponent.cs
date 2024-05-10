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

    // ���� ������Ʈ���� ȣ���� ��������Ʈ �ν��Ͻ�
    public IComponent.PartsUse D_Equip;
    public IComponent.PartsUse D_Use;
    public IComponent.PartsUse D_Dispose;

    /// <summary>
    /// ���̽� �̴ϼȶ������ �׻� �������ٿ� �־��ּ���
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
        // ������Ʈ�������ν� ����� �ż���

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