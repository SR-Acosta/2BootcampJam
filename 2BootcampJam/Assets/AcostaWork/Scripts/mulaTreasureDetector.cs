using System;using 
System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class mulaTreasureDetector : MonoBehaviour
{
    private AIDestinationSetter targetManager;
    private Transform reloadPlayer;
    private Transform treasureDetected;
    private Transform meta;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetManager = GetComponentInParent<AIDestinationSetter>();
        targetManager.target = GameObject.FindWithTag("Player").transform;
        reloadPlayer = GameObject.FindWithTag("Player").transform;
        meta = GameObject.FindWithTag("Finish").transform;
    }
    private void Update()
    {
        allTreasures();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            targetManager.target = other.transform;
        }
        else if (other.gameObject.tag == "Player" && _gameManager.recollectedTreasures == 0)
        {
            targetManager.target = reloadPlayer;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            targetManager.target = reloadPlayer;
        }
    }
    private void allTreasures()
    {
        if (_gameManager.recollectedTreasures == 3)
        {
            targetManager.target = meta;
        }
    }
}
