﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Pathfinding;

public class WaveSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject[] enemyPrefabs;
    [SerializeField] private int wave = 1;
    public Transform spawnsParent;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    void Update()
    {
        int enemyCounter = GameHandler.instance.GetAliveEnemyCounter();
        if(enemyCounter == 0)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        for(int i = 0; i < wave; i++)
        {
            Vector3 offset = (UnityEngine.Random.insideUnitCircle).normalized * 3f;
            Vector3 spawnPos = spawnsParent.GetChild(Random.Range(0,spawnsParent.childCount)).position + offset;
            //Debug.Log(spawnPos);

            GameObject prefab = enemyPrefabs[0];
            int random = Random.Range(0, 4);
            if (random == 0) prefab = enemyPrefabs[1];
            GameObject ennemy = Instantiate(prefab, spawnPos, Quaternion.identity);
            ennemy.GetComponent<EnemyAI>().target = player;

            GameHandler.instance.AddAliveEnemyToCounter();
        }
        wave++;
    }
}
