using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemySawPlayer : MonoBehaviour
{
   public AIDestinationSetter targetManager;
   public Transform playerDetected;

   
   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         targetManager.target = playerDetected;
      }
   }
}
