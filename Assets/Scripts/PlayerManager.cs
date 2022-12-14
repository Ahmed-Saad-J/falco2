using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [Header("Key Binds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode blockKey = KeyCode.Mouse1;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode dashKey = KeyCode.Space;
    public bool blockpressed;
    public MovementState state;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Gradient gradient;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonMovement= GetComponent<ThirdPersonMovement>();
        playerAnimationStateController= GetComponent<PlayerAnimationStateController>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }


        float delta = Time.deltaTime;
        thirdPersonMovement.HandleGravety(delta);
        thirdPersonMovement.HandleMovement(delta);
        thirdPersonMovement.HandleDash(delta);
        playerAnimationStateController.HandleWalkAndSprintAnim();
        playerAnimationStateController.HandleBlockAndAttack();
        thirdPersonMovement.StateHandler();
        
    }
    

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
