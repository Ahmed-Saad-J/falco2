using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    ThirdPersonMovement thirdPersonMovement;
    PlayerAnimationStateController playerAnimationStateController;
    [Header("Movement stats")]
    public bool grounded;
    public float speed = 8f;
    public float walkingSpeed = 8f;
    public float sprintingSpeed = 11f;

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
        playerAnimationStateController.HandleWalkingAnim();
    }
}
