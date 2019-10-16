using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject[] peoplePrefabs;
    public int peopleIndex;

    public float spawnRangeX = 20;
    public float spawnRangeZ = 20;
    private float startDelay = 2;
    public float spawnInterval = 1.5f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomObject()
    {
        if (gameManager.isFinish == false)
        {
            Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 10, Random.Range(-spawnRangeZ, spawnRangeZ));
            int peopleIndex = Random.Range(0, peoplePrefabs.Length);

            Instantiate(peoplePrefabs[peopleIndex], spawnpos, peoplePrefabs[peopleIndex].transform.rotation);
        }

    }
}
