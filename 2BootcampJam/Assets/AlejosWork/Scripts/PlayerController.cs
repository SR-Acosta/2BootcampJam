using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    private Vector2 direction;
    private void Update()
    {
        movePlayer();
    }
    private void movePlayer()
    {
        /*Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        gameObject.transform.Translate(movement * playerSpeed * Time.deltaTime);*/

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }
        transform.Translate(direction * Time.deltaTime * playerSpeed);
    }
}
