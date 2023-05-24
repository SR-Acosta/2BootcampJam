using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class mulaEnemyDetection : MonoBehaviour
{
    public AIPath aiPath;


    private void Start()
    {
        aiPath = GetComponent<AIPath>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //aiPath.canMove = false;
            aiPath.enabled = !aiPath.enabled;
        }
        else
        {
            aiPath.enabled = aiPath.enabled;
        }
    }
}
