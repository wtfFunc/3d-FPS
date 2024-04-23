using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance = null;

    public PlayerObjectData m_PlayerStat;

    public PlayerControllSetting m_GetPlayerSetting;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[SerializeField]
public class PlayerControllSetting
{
    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Vector3 velocity;

    public AudioClip footStepSound;
    public float footStepDelay;

    public float nextFootstep = 0;

    bool isGrounded;
}

