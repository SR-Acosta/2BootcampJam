using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class waveManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    //public int recollectedTreasures;

    public float tiempoEnemigos;
    public float tiempoSiguienteEnemigo;

    public int wave;
    public int enemyType;
    
    private void Start()
    {
        wave = 1;
    }
    private void Update()
    {
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
        if (wave == 1)
        {
            enemyType = 1;
        }
        else if (wave < 4)
        {
            enemyType = Random.Range(0,2);
        }
        else
        {
            enemyType = Random.Range(0,3);
        }
        Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, 
            spawnPoints[spawnPos].transform.rotation);
    }
}