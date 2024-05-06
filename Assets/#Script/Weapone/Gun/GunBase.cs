using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public GunScriptable gunData;


    [Header("Resource")]
    public AudioSource fireSound;
    public AudioSource reLoadingSound;


    public abstract void Equip();

    public abstract void Use();

    public abstract void Drop();

}

public enum RIFLE_TYPE
{
    AR,
    SR,
    DMR
}
