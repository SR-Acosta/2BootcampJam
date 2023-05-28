using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class damageEnemySword : MonoBehaviour
{
   public float attackDamage;
   private mulaLife _mulaLife;
   private playerLife _playerLife;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         other.gameObject.GetComponent<playerLife>().TakeDamagePlayer(attackDamage);
      }
      if (other.gameObject.tag == "Mula")
      {
         other.gameObject.GetComponent<mulaLife>().TakeDamageMula(attackDamage);
      }
   }
}
