using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class skelletonGX : MonoBehaviour
{
    private Transform skellGX;
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
            anim.SetFloat("skMoving", distance.x);
        }
        if (distance.x < -0.2f)
        {
            skellGX.transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
            anim.SetFloat("skMoving", distance.x);
        }
    }
}
