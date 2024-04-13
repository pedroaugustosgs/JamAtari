using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para spawnar os barris
public class Spawn : MonoBehaviour
{
    public GameObject barrelPrefab; // Prefab do barril
    public float spawnTimeMin = 2.0f; // Tempo entre os spawns
    public float spawnTimeMax = 5.0f; // Tempo entre os spawns
    public float spawnDelay = 2.0f; // Tempo para começar a spawnar

    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    // Update is called once per frame
    void Spawner()
    {
        
        Instantiate(barrelPrefab, transform.position, Quaternion.identity);
        
        Invoke("Spawner", Random.Range(spawnTimeMin, spawnTimeMax));

    }
}
