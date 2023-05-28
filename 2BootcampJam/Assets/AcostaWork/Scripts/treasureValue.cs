using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class treasureValue : MonoBehaviour
{
    private GameManager _GM;
    public int value = 1;
    private void Start()
    {
        _GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mula")
        {
            _GM.recollectedTreasures += value;
            _GM.totalTreasures += value;
            Destroy(gameObject);
        }
    }
}
