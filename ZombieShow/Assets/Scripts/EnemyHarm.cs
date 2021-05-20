using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
