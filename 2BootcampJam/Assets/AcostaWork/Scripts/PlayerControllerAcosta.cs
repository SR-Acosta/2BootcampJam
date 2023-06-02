using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerAcosta : MonoBehaviour
{
    public float playerSpeed;
    private Vector2 direction;
    private float lastX;
    public Transform playerGX;
    public Transform lifeBarGX;
    public Animator anim;
    private MeleeCombat _mc;
    //private Rigidbody2D _rigidbody;
    public float canMove;
    public bool canAttack;
    private void Start()
    {
        canMove = 1;
        canAttack = true;
        anim = GetComponent<Animator>();
        _mc = GetComponent<MeleeCombat>();
    }
    private void Update()
    {
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
        transform.Translate(direction * Time.deltaTime * playerSpeed * canMove);
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("AnimState", 2);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
            anim.SetInteger("AnimState", 0);
            anim.SetInteger("AnimState", 0);
        }
        
    }
    private void attackPlayer()
    {
        if (Input.GetKeyDown("k") || Input.GetButtonDown("Fire1"))
        {
            //anim.SetTrigger("Attack");
            anim.SetBool("IsAttacking", true);
            canMove = 0;
            //StartCoroutine(LockPlayerMovement());

        }

        if (Input.GetKeyUp("k") || Input.GetButtonUp("Fire1"))
        {
            if (canAttack)
            {
                _mc.Attack();
                canAttack = false;
                StartCoroutine(LockPlayerAttack());
            }            
            anim.SetBool("IsAttacking",false);
            StartCoroutine(LockPlayerMovement());
        }

    }
    private void SideTurning() //Function in charge of flipping the player sprite and it's children on que X axis, thanks to Santi Acosta, what a bless mano
    {        
        if (Input.GetAxis("Horizontal") > 0) //This condition works visually better... but... who knows if the Acosta's aproach was a better practice.
        {
            playerGX.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            lifeBarGX.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            //_rigidbody.isKinematic = false;

        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            playerGX.transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
            lifeBarGX.transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
            //_rigidbody.isKinematic = false;

        }
        lastX = transform.position.x;
    }

    private IEnumerator LockPlayerMovement()
    {
        //isMoving = 0;
        yield return new WaitForSeconds(1f);
        canMove = 1;
    }
    private IEnumerator LockPlayerAttack()
    {
        //isMoving = 0;
        yield return new WaitForSeconds(0.7f);
        canAttack = true;
    }
}