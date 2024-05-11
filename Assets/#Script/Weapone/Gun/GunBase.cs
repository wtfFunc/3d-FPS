using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public abstract class GunBase : MonoBehaviour
{
    public GunScriptable gunData;


    public delegate void GunFire();

    public GunFire del;


    [Header("Resource")]
    public AudioSource fireSound;
    public AudioSource reLoadingSound;


    [Header("PartsPos")]
    public Transform camPos;

    [Header("PartsPos")]
    public List<IWeaponeState> child;


    public float bulletCircleRadian = 0.0f;


    // Ballistics parameters
    public int segments = 1000;
    public Transform startPoint; // 시작 위치
    public Transform endPoint; // 목표 지점

    protected LineRenderer lineRenderer;

    // 1 = 1m
    protected int maxDistance = 1000;

    public abstract void Equip();

    public abstract void Use();

    public abstract void Dispose();


    protected void Shot()
    {
        // 방향설정 + 탄착군범위설정 ( 0 = 레이저)
        float x, y;
        x = Random.Range(-bulletCircleRadian, bulletCircleRadian);
        y = Random.Range(-bulletCircleRadian, bulletCircleRadian);
        Vector3 direction = new Vector3(x, y, 1f);
        
            
    }


    protected List<Vector3> Ballistics()
    {
        return null;
    }

    protected void DrawCurve()
    {
        lineRenderer.positionCount = segments;
        for (int i = 0; i < segments; i++)
        {
            float t = i / (float)segments;

            Vector3 position = CalculateBezierPoint(
                t, startPoint.position,
                startPoint.position + startPoint.forward * 1000f,
                endPoint.position
                );

            lineRenderer.SetPosition(i, position);
        }
    }

    // 베지어 곡선 계산
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * endPoint.position;

        return p;
    }
}

public enum RIFLE_TYPE
{
    AR,
    SR,
    DMR
}
