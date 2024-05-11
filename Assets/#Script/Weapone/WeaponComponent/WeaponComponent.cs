using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponComponent : MonoBehaviour, IWeaponeState
{

    public E_PartsType componentType;

    protected UnityAction _useAction;

    protected UnityAction _equipAction;

    protected UnityAction _disuseAction;

    // ���� ������Ʈ���� ȣ���� ��������Ʈ �ν��Ͻ�
    public IWeaponeState.PartsUse D_Equip;
    public IWeaponeState.PartsUse D_Use;
    public IWeaponeState.PartsUse D_Dispose;

    /// <summary>
    /// ���̽� �̴ϼȶ������ �׻� �������ٿ� �־��ּ���
    /// </summary>
    public virtual void Init()
    {
        D_Equip         = new IWeaponeState.PartsUse(_useAction);
        D_Use           = new IWeaponeState.PartsUse(_equipAction);
        D_Dispose       = new IWeaponeState.PartsUse(_disuseAction);
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



}
public enum E_PartsType
{
    scope,
    magazine,
    handle,
    muzzle
}