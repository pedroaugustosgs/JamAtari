using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] barrelPrefab;
    public GameObject gm;
    public float spawnTimeMin = 2.0f;
    public float spawnTimeMax = 5.0f;
    public float spawnDelay = 2.0f;

    //Animação tonhao
    Animator animatorTonhao;
    
    void Start()
    {
        animatorTonhao = GetComponent<Animator>();
        Spawner();
        
    }

    void Spawner()
    {
        int roupaCorreta = gm.GetComponent<GameManager>().roupaCorreta;

        // Cria uma lista de índices de barris possíveis
        List<int> possibleBarrels = new List<int>();
        for (int i = 0; i < barrelPrefab.Length; i++)
        {
            if (i == roupaCorreta)
            {
                // Adiciona o índice do barril correto uma vez
                possibleBarrels.Add(i);
            }
            else
            {
                // Adiciona os índices dos outros barris duas vezes
                possibleBarrels.Add(i);
                possibleBarrels.Add(i);
            }
        }
        

        // Escolhe um índice aleatório da lista de barris possíveis
        int randomBarrel = possibleBarrels[Random.Range(0, possibleBarrels.Count)];

        Instantiate(barrelPrefab[randomBarrel], transform.position, Quaternion.identity);


        
        Invoke("Spawner", Random.Range(spawnTimeMin, spawnTimeMax));
        animatorTonhao.CrossFade("tonhao_working", 0, 0);


    }
}