using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class makeDamageEnemy : MonoBehaviour
{
    private enemyLife _enemyLife;
    public float attackDamage;
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemyLife>().TakeDamage(attackDamage);
        }
    }
}
