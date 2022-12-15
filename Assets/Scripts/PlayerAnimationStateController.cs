using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator animm;
    PlayerManager playerManager;
    PlayerAttack playerAttack;

    void Start()
    {
        animm = GetComponentInChildren<Animator>();
        playerManager = GetComponent<PlayerManager>();
        playerAttack= GetComponent<PlayerAttack>();

    }

    // Update is called once per frame
 
    public void HandleWalkAndSprintAnim()
    {

            
        bool sprintPressed = Input.GetKey(playerManager.sprintKey);
        if (ThirdPersonMovement.direction.magnitude >= 0.1f)
        {
            animm.SetBool("walk", true);
        }
        else
        {
            animm.SetBool("walk", false);
        }
        
        if (sprintPressed)
        {
            if (playerManager.isInteracting)
            {
                animm.SetBool("sprint", false);
                return;
            }
            animm.SetBool("sprint", true);
        }
        else
        {
            animm.SetBool("sprint", false);
        }
    }

    public void HandleBlockAnim()
    {
        bool blockPressed = Input.GetKey(playerManager.blockKey);
        if (blockPressed)
        {
            animm.SetBool("block", true);
            animm.SetBool("isInteracting", true);
        }
        else
        {
            animm.SetBool("block", false);
        }

    }
    public void isInteracting()
    {
        playerManager.isInteracting = animm.GetBool("isInteracting");
        playerManager.isAttack1 = animm.GetBool("hit1");
        playerManager.isAttack2 = animm.GetBool("hit2");
    }

    public void HandleAttackAnim() 
    {
        if ((animm.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f || animm.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f) && (animm.GetCurrentAnimatorStateInfo(0).IsName("attack1") || animm.GetCurrentAnimatorStateInfo(1).IsName("attack1")))
        {
           
            animm.SetBool("hit1", false);
        }

        if ((animm.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f || animm.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f) && (animm.GetCurrentAnimatorStateInfo(0).IsName("attack2") || animm.GetCurrentAnimatorStateInfo(1).IsName("attack2")))
        {
            animm.SetBool("hit2", false);
            PlayerAttack.numOfClicks = 0;

        }

        bool AttackPressed = Input.GetKeyDown(playerManager.attackKey);
        if (Time.time - playerAttack.lastClickTime > playerAttack.maxComboDelay)
        {
            PlayerAttack.numOfClicks = 0;
        }
        if(Time.time > playerAttack.nextFiretime)
        {
            if (AttackPressed)
            {
                OnClick();
            }
        }
    }
    void OnClick()
    {
        playerAttack.lastClickTime = Time.time;
        PlayerAttack.numOfClicks++;
        if (PlayerAttack.numOfClicks == 1)
        {
            animm.SetBool("hit1", true);
            //animm.SetBool("isInteracting", true);
            
        }
       
        PlayerAttack.numOfClicks = Mathf.Clamp(PlayerAttack.numOfClicks, 0, 2);
        if(PlayerAttack.numOfClicks >= 2 && (animm.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f || animm.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.4f) && (animm.GetCurrentAnimatorStateInfo(0).IsName("attack1")|| animm.GetCurrentAnimatorStateInfo(1).IsName("attack1")))
        {
            //Debug.Log("hamada");
            animm.SetBool("hit1", false);
            animm.SetBool("hit2", true);
            //anim.SetBool("isInteracting", true);
            PlayerAttack.numOfClicks = 0;
        }

    }

    public void OnImpactAnim()
    {
        animm.SetBool("takenDamage", true);
    }
    public void OnDeathAnim() 
    {
        animm.SetBool("dead", true);
    }
}
