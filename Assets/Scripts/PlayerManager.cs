using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ThirdPersonMovement;

public class PlayerManager : MonoBehaviour
{
 
    ThirdPersonMovement thirdPersonMovement;
    PlayerAnimationStateController playerAnimationStateController;
    [Header("Movement stats")]
    public float speed = 8f;
    public float walkingSpeed = 8f;
    public float sprintingSpeed = 11f;
    public float dashSpeed;
    public float dashTime;
    [Header("Flags")]
    public bool grounded;
    public bool isInteracting;
    public bool isWalking;
    public bool isSprinting;
    public bool isBlocking;
    public bool isAttack1;
    public bool isAttack2;


    [Header("Key Binds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode blockKey = KeyCode.Mouse1;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode dashKey = KeyCode.Space;
    
    public MovementState state;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonMovement= GetComponent<ThirdPersonMovement>();
        playerAnimationStateController= GetComponent<PlayerAnimationStateController>();
    

    }

    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime;
        thirdPersonMovement.HandleGravety(delta);
        thirdPersonMovement.HandleMovement(delta);
        thirdPersonMovement.HandleDash(delta);
        playerAnimationStateController.HandleWalkAndSprintAnim();
        playerAnimationStateController.HandleBlockAnim();
        playerAnimationStateController.HandleAttackAnim();
        playerAnimationStateController.isInteracting();
        thirdPersonMovement.StateHandler();
    }
}
