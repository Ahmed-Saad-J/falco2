using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    Animator animator;
    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            if (currentHealth < damage)
            {
                currentHealth = 0;
                //healthBar.SetCurrentHealth(0);
                
            }
            else
            {
                currentHealth -= damage;
                animator.Play("EnemyImpact_1");
                //healthBar.SetCurrentHealth(currentHealth);
                
            }
        }
    }
}
