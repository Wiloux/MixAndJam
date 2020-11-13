using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WaveSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject ennemyPrefab;
    [SerializeField] private int wave = 1;
    public float spawnDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();

        InvokeRepeating("SpawnWave", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnWave()
    {
        for(int i = 0; i < wave; i++)
        {
            Vector3 spawnPos = (UnityEngine.Random.insideUnitCircle).normalized * spawnDistance; 
            Debug.Log(spawnPos);

            GameObject ennemy = Instantiate(ennemyPrefab, spawnPos, Quaternion.identity);
            ennemy.GetComponent<AIDestinationSetter>().target = player;
        }
        wave++;
    }
}
