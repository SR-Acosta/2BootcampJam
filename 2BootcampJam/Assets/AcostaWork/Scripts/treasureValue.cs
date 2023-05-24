using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureValue : MonoBehaviour
{
    private GameManager _GM;

    private void Start()
    {
        _GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _GM.recollectedTreasures += 1;
            Destroy(gameObject);
        }
    }
}
