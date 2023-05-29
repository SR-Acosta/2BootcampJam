using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class mulaGX : MonoBehaviour
{
   public Transform cargaGX;
   public Transform barraVidaBurro;
   private AIPath _ai;
   private Animator anim;

   private void Start()
   {
      anim = GetComponent<Animator>();
      _ai = GetComponent<AIPath>();
   }
   void Update()
   {
      SideTurning();
      mulaWalks();
   }
   private void SideTurning()
   {
      Vector2 distance = _ai.desiredVelocity;
      if (distance.x > 0.2f)
      {
         cargaGX.transform.localScale = new Vector3(-1f, 1f, 1f);
         barraVidaBurro.transform.localScale = new Vector3(-1f, 1f, 1f);
         
      }
      if (distance.x < -0.2f)
      {
         cargaGX.transform.localScale = new Vector3(1f, 1f, 1f);
         barraVidaBurro.transform.localScale = new Vector3(1f, 1f, 1f);
      }
   }

   private void mulaWalks()
   {
      if (_ai.canMove == true)
      {
         anim.SetBool("isWalking",true);
      }

      else if (_ai.canMove == false)
      {
         anim.SetBool("isWalking",false);
      }
   }
}
