using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public bool isAttacking = false;
    [SerializeField]
    private Transform attackController;//Not sure what this does
    [SerializeField]
    private float attackRadius;//As damage has circular shape, asigns the radius os such circular area
    [SerializeField]
    private float attackDamage;//damage quantity
    [SerializeField]
    private float attackInterval;
    private float timeSinceLastAttack;
    private void Update()
    {
        AttackTimeManager();
    }
    private void AttackTimeManager ()
    {
        if (timeSinceLastAttack > 0)
        {
            timeSinceLastAttack -= Time.deltaTime;
            
        }
        if (timeSinceLastAttack <= 0)
        {
            //isAttacking = false;
        }
        if (Input.GetButtonDown("Fire1") && timeSinceLastAttack <= 0)
        {
            Attack();
            isAttacking = true;
            timeSinceLastAttack = attackInterval;
        }
    }
    private void Attack()
    {
        Collider2D[] attackedObjects = Physics2D.OverlapCircleAll(attackController.position, attackRadius);//this tracks the objects reached by the player's attack
        foreach (Collider2D attackedObject in attackedObjects)
        {
            if (attackedObject.CompareTag("Enemy") || attackedObject.CompareTag("WeakWall"))
            {
                attackedObject.transform.GetComponent<DamageTaker>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadius);
    }
}
