using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHarm : MonoBehaviour
{
    private Text text;
    private GameObject spawnManager;
    private bool needsToWait;

    void Start()
    {
        text = GameObject.Find("EnemiesAlive").GetComponent<Text>();
        spawnManager = GameObject.Find("SpawnManager");
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Bullet" && needsToWait == false)
        {

            Destroy(other.gameObject);
            Destroy(this.gameObject);

            DecrementsEnemiesAlive();
            StartCoroutine("Wait");
        }
        

    }

    //Method that prevents double Trigger using needsToWait flag
    private IEnumerator Wait()
    {
        needsToWait = true;
     
        yield return new WaitForSeconds(2f);

        //Flag that is only updated 2 seconds after
        needsToWait = false;
    }

    //Method that accesses SpawnManager Script, decrements enemies Alive and
    // updates TEXT UI
    void DecrementsEnemiesAlive()
    {
        
        spawnManager.GetComponent<SpawnManager>().enemiesAlive--;
        spawnManager.GetComponent<SpawnManager>().UpdateEnemiesAliveText();
    }
}
