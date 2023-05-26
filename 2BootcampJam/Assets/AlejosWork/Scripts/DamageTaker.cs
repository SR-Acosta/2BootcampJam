    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField]
    private float health;
    public void TakeDamage(float damage)
    {
        if(health > 0f)
        {
            health -= damage;
        }
        else
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
