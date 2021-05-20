using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    //Attack area
    public Collider hitBox;
    //Player Layer
    public LayerMask playerLayer;

    public Animator animator;

    private bool attackAllowed;

    //Methos that causes damage to the player
    void Damage()
    {
        Collider[] hit;
        hit = Physics.OverlapBox(hitBox.bounds.center, hitBox.bounds.extents, hitBox.transform.rotation, playerLayer);
        if(hit.Length == 1)
        {
            hit[0].GetComponent<HPManager>().LooseHP(1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Damage();
        }
    }
}
