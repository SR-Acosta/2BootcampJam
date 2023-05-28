using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemySawPlayer : MonoBehaviour
{
   private AIDestinationSetter targetManager;
   private Transform playerDetected;
   private Transform reloadMula;
   private Animator anim;
   private void Start()
   {
      anim = GetComponentInParent<Animator>();
      targetManager = GetComponentInParent<AIDestinationSetter>();
      targetManager.target = GameObject.FindWithTag("Mula").transform;
      playerDetected = GameObject.FindWithTag("Player").transform;
      reloadMula =  GameObject.FindWithTag("Mula").transform;
   }
   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         targetManager.target = playerDetected;
         anim.SetBool("isAttacking",false);
      }
   }
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         targetManager.target = reloadMula;
      }
   }
}
