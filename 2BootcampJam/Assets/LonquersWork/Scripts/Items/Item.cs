using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the item collision
        if (other.gameObject.CompareTag("Player"))
        {
            // Increased the player's attack power
            other.gameObject.GetComponent<IncreaseAttackDamagePlayer>().IncreaseAttackDamage();
            // We destroy the item
            Destroy(gameObject);
        }
    }
}
