using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator anim;
    PlayerManager playerManager;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerManager = GetComponent<PlayerManager>();
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
            anim.SetBool("sprint", true);
        }
        else
        {
            anim.SetBool("sprint", false);
        }
    }

    public void HandleBlockAndAttack()
    {
        bool blockPressed = Input.GetKey(playerManager.blockKey);
        if (blockPressed)
        {
            anim.SetBool("block", true);
        }
        else
        {
            anim.SetBool("block", false);
        }

    }
}
