using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LonquersWork.Scripts
{
    public class EnemyDie : MonoBehaviour
    {
        [Header("Item configuration")]
        [Tooltip("You need to drag the prefab of the item that we want the enemy to drop, note that it must be a prefab")]
        // Prefab of the item that we want the enemy to drop
        public GameObject itemPrefab;
        
        private float randomNumber;
        
        [Header("Min Value configuration")]
        [Tooltip("this is the minimum value that the random number can take")]
        public float minValue = 0;
        [Header("Max Value configuration")]
        [Tooltip("This is the maximum value that the random number can take")]
        public float maxValue = 9;
        [Header("Lottery configuration")]
        [Tooltip("This is the number that the random number must match to drop the item")]
        public float lottery = 0;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            // If the player passes over the enemy
            if (other.gameObject.CompareTag("Player"))
            {
                // we defeat the enemy
                Defeat();
            }
        }
   
        // We call this function when the enemy is defeated
        private void Defeat()
        {
            randomNumber = Random.Range(minValue, maxValue);
            if (randomNumber == lottery)
            {
                // we create the item in the enemy's position
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
            // we defeat the enemy
            Destroy(gameObject);
        }
    }
}
