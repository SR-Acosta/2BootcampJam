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
        
        [Header("Min Value configuration")]
        [Tooltip("this is the minimum value that the random number can take")]
        public int minValue = 0;
        [Header("Max Value configuration")]
        [Tooltip("This is the maximum value that the random number can take")]
        public int maxValue = 0;
        [Header("Lottery configuration")]
        [Tooltip("This is the number that the random number must match to drop the item")]
        public int lottery = 0;
        
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
            float randomNumber = Random.Range(minValue, maxValue);
            Debug.Log(randomNumber);
            if (Mathf.Approximately(randomNumber, lottery))
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
