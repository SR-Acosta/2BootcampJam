using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    //public bool isAttacking = false;
    [SerializeField]
    private Transform attackController;//Not sure what this does
    [SerializeField]
    private float attackRadius;//As damage has circular shape, asigns the radius os such circular area
    [SerializeField]
    private float attackDamage;//damage quantity
    [SerializeField]
    /*private void Update()
    {
        AttackTimeManager();
    }*/
    private void AttackTimeManager ()
    {
        Attack();
    }
    public void Attack()
    {
        Collider2D[] attackedObjects = Physics2D.OverlapCircleAll(attackController.position, attackRadius);//this tracks the objects reached by the player's attack
        foreach (Collider2D attackedObject in attackedObjects)
        {
            if (attackedObject.CompareTag("Enemy"))
            {
                attackedObject.transform.GetComponent<Animator>().SetTrigger("wasHit1");
                attackedObject.transform.GetComponent<Animator>().SetBool("wasHit",true);
                attackedObject.transform.GetComponent<enemyLife>().TakeDamage(attackDamage);
            }
        }
    }

   /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadius);
    }*/
}
