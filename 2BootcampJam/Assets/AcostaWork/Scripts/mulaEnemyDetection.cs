using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class mulaEnemyDetection : MonoBehaviour
{
    private AIPath aiPath;
    private void Start()
    {
        aiPath = GetComponentInParent<AIPath>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            aiPath.canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            aiPath.canMove = true;
        }
    }
}
