using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class skelletonGX : MonoBehaviour
{
    private Transform skellGX;
    public Transform skLifeBarGX;
    private AIPath _aiP;
    private Animator anim;
    private void Start()
    {
        skellGX = GetComponent<Transform>();
        _aiP = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        SideTurning();
    }
    private void SideTurning()
    {
        Vector2 distance = _aiP.desiredVelocity;
        if (distance.x > 0.2f)
        {
            skellGX.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            skLifeBarGX.transform.localScale = new Vector3(1f, 1f, 1f);
            anim.SetFloat("skMoving", distance.x);
        }
        if (distance.x < -0.2f)
        {
            skellGX.transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
            skLifeBarGX.transform.localScale = new Vector3(-1f, 1f, 1f);
            anim.SetFloat("skMoving", distance.x);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Attacks")
        {
            anim.SetTrigger("wasHit1");
            anim.SetBool("wasHit",false);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Attacks")
        {
            anim.ResetTrigger("wasHit1");
            anim.SetBool("wasHit",true);
        }    
    }
}
