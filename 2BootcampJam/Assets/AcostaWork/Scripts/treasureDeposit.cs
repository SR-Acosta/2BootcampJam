using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class treasureDeposit : MonoBehaviour
{
    private GameManager _gameManager;
    private treasureSpawn _treasureSpawn;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _treasureSpawn = GameObject.Find("GameManager").GetComponent<treasureSpawn>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mula")
        {
            if ( Input.GetKeyDown("l"))
            {
                if (_gameManager.recollectedTreasures == 3)
                {
                    Debug.Log("resetTreasures");
                    _gameManager.recollectedTreasures -= 3;
                    _treasureSpawn.regulatorTreasure -= 3;
                }
                else if (_gameManager.recollectedTreasures < 3)
                {
                    Debug.Log("not enough");
                }
            }
        }
    }
}
