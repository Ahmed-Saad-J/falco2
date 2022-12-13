using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;
    EnemyStats enemyStats;
    public int currentDamage;
    private void Awake()
    {
        damageCollider= GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger= true;
        damageCollider.enabled=false;
    }
    public void EnableDamageCollider()
    {
        damageCollider.enabled=true;
    } 

    public void DisableDamageCollider()
    {
        damageCollider.enabled=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyStats = other.GetComponent<EnemyStats>();
            if(enemyStats!= null )
            {
                enemyStats.TakeDamage(currentDamage);
            }
        }
    }
}
