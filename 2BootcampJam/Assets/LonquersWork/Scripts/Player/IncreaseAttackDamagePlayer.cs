using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttackDamagePlayer : MonoBehaviour
{
    [Header("Attack configuration")]
    [Tooltip("You can change the initial value of the player's attack power")]
    public int attackDamage = 1; 

    //We call this function when the player picks up a power item
    public void IncreaseAttackDamage()
    {
        attackDamage++;
    }
}
