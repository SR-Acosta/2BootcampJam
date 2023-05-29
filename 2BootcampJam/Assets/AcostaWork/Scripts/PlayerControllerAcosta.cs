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
    public Transform lifeBarGX;
    public Animator anim;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
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
        transform.Translate(direction * Time.deltaTime * playerSpeed);
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }
    private void attackPlayer()
    {
        if (Input.GetKeyDown("k"))
        {
            anim.SetBool("isAttacking",true);
            _rigidbody.isKinematic = true;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

        }

        if (Input.GetKeyUp("k"))
        {
            anim.SetBool("isAttacking",false);

        }

        if (Input.GetKeyDown("d"))
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        if (Input.GetKeyDown("a"))
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        if (Input.GetKeyDown("s"))
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        if (Input.GetKeyDown("w"))
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
    private void SideTurning() 
        //Function in charge of flipping the player sprite and it's children on que X axis, thanks to Santi Acosta, what a bless mano
    {
        if (transform.position.x - lastX > 0)
        {
            playerGX.transform.localScale = new Vector3(1f, 1f, 1f);
            lifeBarGX.transform.localScale = new Vector3(1f, 1f, 1f);
            _rigidbody.isKinematic = false;

        }

        if (transform.position.x - lastX < 0)
        {
            playerGX.transform.localScale = new Vector3(-1f, 1f, 1f);
            lifeBarGX.transform.localScale = new Vector3(-1f, 1f, 1f);
            _rigidbody.isKinematic = false;

        }
        lastX = transform.position.x;
    }
}