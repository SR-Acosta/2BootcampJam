using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    private Vector2 direction;
    private float lastX;
    public Transform playerGX;
    private void Update()
    {
        MovePlayer();
        SideTurning();
    }
    private void MovePlayer()//Simple normalized Player movement function
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }
        transform.Translate(direction * Time.deltaTime * playerSpeed);
    }
    private void SideTurning()//Function in charge of flipping the player sprite and iths children on que X axis, thanks to Santi Acosta, what a bendición mano
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
