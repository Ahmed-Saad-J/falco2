using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerAnimationStateController playerAnimationStateController;
    ThirdPersonMovement thirdPersonMovement;
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        playerAnimationStateController = GetComponent<PlayerAnimationStateController>();
        thirdPersonMovement= GetComponent<ThirdPersonMovement>();
        maxHealth = SetMaxHealthForLevel();
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    private int SetMaxHealthForLevel()
    {
        maxHealth= healthLevel*11;
        return maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if(currentHealth > 0) { 
            if (currentHealth < damage) 
            {
                currentHealth = 0;
                //healthBar.SetCurrentHealth(0);
                playerAnimationStateController.OnDeathAnim();
                //handle player death
                thirdPersonMovement.controller.enabled= false;
            }
            else
            {
                currentHealth -= damage;
                //healthBar.SetCurrentHealth(currentHealth);
                playerAnimationStateController.OnImpactAnim();
            }
        }
    }

}
