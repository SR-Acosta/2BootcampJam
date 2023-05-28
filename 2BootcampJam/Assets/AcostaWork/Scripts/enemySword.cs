using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class enemySword : MonoBehaviour
{
   private Animator anim;
   private void Start()
   {
      anim = GetComponentInParent<Animator>();
   }
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         anim.SetBool("isAttacking", true);
      }
      if (other.gameObject.tag == "Mula")
      {
         anim.SetBool("isAttacking", true);
      }
   }
   private void OnCollisionStay2D(Collision2D other)
   {
      if (other.gameObject.tag == "Mula")
      {
         anim.SetBool("isAttacking", true);
      }
      if (other.gameObject.tag == "Player")
      {
         anim.SetBool("isAttacking", true);
      }
   }
   private void OnCollisionExit2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         anim.SetBool("isAttacking",false);
      }
      if (other.gameObject.tag == "Mula")
      {
         anim.SetBool("isAttacking",false);
      }
   }
}