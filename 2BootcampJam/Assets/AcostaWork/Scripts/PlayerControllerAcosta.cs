using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControllerAcosta : MonoBehaviour
{
    public float playerSpeed;
    private Vector2 direction;
    private float lastX;
    public Transform playerGX;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("isAttacking",false);
        MovePlayer();
        SideTurning();
        attackPlayer();
    }
    private void MovePlayer()//Simple normalized Player movement function
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }
        transform.Translate(direction * Time.deltaTime * playerSpeed);
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }
    private void attackPlayer()
    {
        if (Input.GetKeyDown("k"))
        {
            anim.SetBool("isAttacking",true);
        }
    }
    private void SideTurning() 
        //Function in charge of flipping the player sprite and it's children on que X axis, thanks to Santi Acosta, what a bless mano
    {
        if (transform.position.x - lastX > 0)
        {
            playerGX.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (transform.position.x - lastX < 0)
        {
            playerGX.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        lastX = transform.position.x;
    }
}