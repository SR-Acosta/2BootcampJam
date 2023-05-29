using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectTreasure : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            anim.SetBool("treasure",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            anim.SetBool("treasure",false);
        }
    }
}
