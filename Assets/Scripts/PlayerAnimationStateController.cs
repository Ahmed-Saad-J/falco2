using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator anim;
    PlayerManager playerManager;
    PlayerAttack playerAttack;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerManager = GetComponent<PlayerManager>();
        playerAttack= GetComponent<PlayerAttack>();

    }

    // Update is called once per frame
 
    public void HandleWalkAndSprintAnim()
    {

            
        bool sprintPressed = Input.GetKey(playerManager.sprintKey);
        if (ThirdPersonMovement.direction.magnitude >= 0.1f)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        
        if (sprintPressed)
        {
            if (playerManager.isInteracting)
            {
                anim.SetBool("sprint", false);
                return;
            }
            anim.SetBool("sprint", true);
        }
        else
        {
            anim.SetBool("sprint", false);
        }
    }

    public void HandleBlockAnim()
    {
        bool blockPressed = Input.GetKey(playerManager.blockKey);
        if (blockPressed)
        {
            anim.SetBool("block", true);
            anim.SetBool("isInteracting", true);
        }
        else
        {
            anim.SetBool("block", false);
        }

    }
    public void isInteracting()
    {
        playerManager.isInteracting = anim.GetBool("isInteracting");
        playerManager.isAttack1 = anim.GetBool("hit1");
        playerManager.isAttack2 = anim.GetBool("hit2");
    }

    public void HandleAttackAnim() 
    {
        if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f || anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f) && (anim.GetCurrentAnimatorStateInfo(0).IsName("attack1") || anim.GetCurrentAnimatorStateInfo(1).IsName("attack1")))
        {
            Debug.Log("Hamada");
            anim.SetBool("hit1", false);
        }

        if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f || anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f) && (anim.GetCurrentAnimatorStateInfo(0).IsName("attack2") || anim.GetCurrentAnimatorStateInfo(1).IsName("attack2")))
        {
            anim.SetBool("hit2", false);
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
            anim.SetBool("hit1", true);
            //anim.SetBool("isInteracting", true);
            
        }
       
        PlayerAttack.numOfClicks = Mathf.Clamp(PlayerAttack.numOfClicks, 0, 2);
        if(PlayerAttack.numOfClicks >= 2 && (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f || anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.4f) && (anim.GetCurrentAnimatorStateInfo(0).IsName("attack1")|| anim.GetCurrentAnimatorStateInfo(1).IsName("attack1")))
        {
            //Debug.Log("hamada");
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
            //anim.SetBool("isInteracting", true);
            PlayerAttack.numOfClicks = 0;
        }

    }

    public void OnImpactAnim()
    {
        anim.SetBool("takenDamage", true);
    }
    public void OnDeathAnim() 
    {
        anim.SetBool("dead", true);
    }
}
