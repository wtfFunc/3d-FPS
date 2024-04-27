using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FsmPlayerMove : FsmState<FSM_PLAYER_STATE>
{
    private PlayerControllSetting playerSetting;
    bool isGrounded;
    public FsmPlayerMove() : base(FSM_PLAYER_STATE.MOVE)
    {
        
    }


    public override void Enter()
    {
        if (playerSetting == null)
        {
            playerSetting = PlayerManager.instance.m_GetPlayerSetting;
        }
        else
        {
            Debug.LogError("Can't Find \"Player Singleton Instance\" Please Get Instance");
        }
        base.Enter();
    }
    public override void Loop()
    {

        isGrounded = Physics.CheckSphere(
            playerSetting.groundCheck.position, playerSetting.groundDistance, playerSetting.groundMask
            );

        if (isGrounded && playerSetting.velocity.y < 0)
        {
            playerSetting.velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (z >= 0.01f)
        {
            PlayerManager.instance.player.m_PlayerAnimator.SetFloat("Vertical", 0.4f);
        }
        else if(z <= -0.01f)
        {
            PlayerManager.instance.player.m_PlayerAnimator.SetFloat("Vertical", -0.4f);
        }
        else
        {
            PlayerManager.instance.player.m_PlayerAnimator.SetFloat("Vertical", 0f);
        }
        PlayerManager.instance.player.m_PlayerAnimator.SetFloat("Horizontal", x);
        //PlayerManager.instance.player.m_PlayerAnimator.SetFloat("y",z);

        Vector3 motion = playerSetting.controller.gameObject.transform.right * x + playerSetting.controller.gameObject.transform.forward * z;
        playerSetting.controller.Move(motion * playerSetting.speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerSetting.velocity.y = Mathf.Sqrt(playerSetting.jumpHeight * -2f * playerSetting.gravity);
        }

        playerSetting.velocity.y += playerSetting.gravity * Time.deltaTime;
        playerSetting.controller.Move(playerSetting.velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && isGrounded)
        {
            playerSetting.nextFootstep -= Time.deltaTime;
            if (playerSetting.nextFootstep <= 0)
            {
                playerSetting.controller.gameObject.GetComponent<AudioSource>().PlayOneShot(playerSetting.footStepSound, 0.7f);
                playerSetting.nextFootstep += playerSetting.footStepDelay;
            }
        }
        base.Loop();
    }
    public override void End()
    {
        base.End();
    }
}

