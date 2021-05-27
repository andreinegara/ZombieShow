using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;

    //List that cointains all the possible locations to spawn Enemies
    public List<Transform> spawnLocations = new List<Transform>();

    private Text text;

    public int enemiesAlive;

    //Flag that allows enemies to spawn
    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        enemiesAlive = 0;
        text = GameObject.Find("EnemiesAlive").GetComponent<Text>();
        CompleteLocationList();
        float spawnTime = Random.Range(5f, 20f);
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    //Method that Adds all the children contained in gameObject
    // SpawnManager to the List
    void CompleteLocationList()
    {
        foreach (Transform child in transform)
        {
            spawnLocations.Add(child);

        }

    }

    void Spawn()
    {
        if (canSpawn)
        {
            //selects a random element number that represents the spawn Location
            int selectedPoint = Random.Range(0, spawnLocations.Count - 1);
            enemiesAlive++;
            UpdateEnemiesAliveText();


            //Creates the enemies
            Instantiate(enemy, spawnLocations[selectedPoint].position, spawnLocations[selectedPoint].rotation);

        }

    }

    //Method that changes the canva text
    public void UpdateEnemiesAliveText()
    { 
        text.text = "Enemies Alive: " + enemiesAlive;
    }
}
