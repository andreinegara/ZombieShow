using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;


    public List<Transform> spawnLocations = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {

        CompleteLocationList();
        float spawnTime = Random.Range(5f, 20f);
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void CompleteLocationList()
    {
        foreach (Transform child in transform)
        {
            spawnLocations.Add(child);


        }

    }

    void Spawn()
    {
        //selects the element number that represents the spawn Location
        int selectedPoint = Random.Range(0, spawnLocations.Count - 1);

        Instantiate(enemy, spawnLocations[selectedPoint].position, spawnLocations[selectedPoint].rotation);

    }
}
