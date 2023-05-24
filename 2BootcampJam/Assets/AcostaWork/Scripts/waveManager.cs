using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class waveManager : MonoBehaviour
{
    public int enemiesSpawned;
    public int difficultyLevel;
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    public float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;
    private int enemyType;
    private GameManager _GM;
    private void Start()
    {
        _GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        difficulty();
        tiempoSiguienteEnemigo += Time.deltaTime;
        if (tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }
    private void CrearEnemigo()
    {
        int spawnPos = Random.Range(0, 4);
        if (_GM.recollectedTreasures == 1)
        {
            enemyType = 0;
        }
        else if (_GM.recollectedTreasures == 2)
        {
            enemyType = Random.Range(0,2);
        }
        else if (_GM.recollectedTreasures == 3)
        {
            enemyType = Random.Range(0,3);
        }
        if (enemiesSpawned < difficultyLevel && _GM.recollectedTreasures >= 1)
        {
            Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, 
                spawnPoints[spawnPos].transform.rotation);
            enemiesSpawned += 1;
        }
    }
    private void difficulty()
    {
        if (_GM.recollectedTreasures == 1)
        {
            difficultyLevel = 5;
        }
        else if (_GM.recollectedTreasures == 2)
        {
            difficultyLevel = 10;
        }
        else if (_GM.recollectedTreasures == 3)
        {
            difficultyLevel = 15;
        }
    }
}