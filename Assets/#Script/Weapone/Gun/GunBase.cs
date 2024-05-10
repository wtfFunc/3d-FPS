using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public delegate void GunFire();

public abstract class GunBase : MonoBehaviour
{
    public GunScriptable gunData;

    public GunFire del;


    [Header("Resource")]
    public AudioSource fireSound;
    public AudioSource reLoadingSound;


    [Header("PartsObject")]
    public Transform camPos;


    public abstract void Equip();

    public abstract void Fire();

    public abstract void Drop();

}

public enum RIFLE_TYPE
{
    AR,
    SR,
    DMR
}
