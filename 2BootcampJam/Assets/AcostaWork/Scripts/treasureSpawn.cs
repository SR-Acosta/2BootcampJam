using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class treasureSpawn : MonoBehaviour
{
    private GameManager _gameManager;
    private int setTreasure;
    public int regulatorTreasure;
    public GameObject[] treasure;
    public GameObject[] spawnPoints;

    
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        spawningTreasure();
    }

    private void spawningTreasure()
    {
        int spawnPos = Random.Range(0, 4);
        setTreasure = Random.Range(0,3);
        if (_gameManager.recollectedTreasures == 0 && regulatorTreasure < 3)
        {
            Instantiate(treasure[setTreasure], spawnPoints[spawnPos].transform.position, 
                spawnPoints[spawnPos].transform.rotation);
            regulatorTreasure += 1;
        }
    }
}
