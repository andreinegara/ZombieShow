using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    //Player's HealthPoints
    public int hp;

    // Start is called before the first frame update

    public void LooseHP(int i)
    {
        hp = hp-i;
        if (hp <=0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
