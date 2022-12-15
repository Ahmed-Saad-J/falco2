using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    Animator animator;
    public int HP = 100;
    public Animator anim;
   

    public void TakeDamage(int damageamount)
    {
       
        HP -= damageamount; 
        if(HP <= 0)
        {
            anim.SetTrigger("Die");
        }
        else
        {
            anim.SetTrigger("Damage");
        }
    }
}
