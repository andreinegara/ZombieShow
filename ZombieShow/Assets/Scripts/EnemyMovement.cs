using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float walkingSpeed;
    public float minimumDistance;
    public CharacterController controller;
    public Animator animator;

    //Direction it will be heading
    public string aimName;
    private Transform aim;


    //Attack area
    public Collider hitBox;

    //Player Layer
    public LayerMask playerLayer;
    public bool attackAllowed;

    // Start is called before the first frame update
    void Start()
    {
        aim = GameObject.Find(aimName).transform;
        attackAllowed = true;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (attackAllowed)
        {
            //will only follow in case of a minimum distance between Enemy and Player
            if (Vector3.Distance(transform.position, aim.position) >= minimumDistance)
            {
                Follow();
            }
            else
            {
                animator.SetBool("isWalking", false);
                Invoke("Attack", 0.5f);
                attackAllowed = false;
            }
        }
    }

    void Follow()
    {
        transform.LookAt(aim.position);
        controller.SimpleMove(transform.forward * walkingSpeed);
        animator.SetBool("isWalking", true);
    }

    //Method that causes damage to the player
    void Damage()
    {
        Collider[] hit;
        hit = Physics.OverlapBox(hitBox.bounds.center, hitBox.bounds.extents, hitBox.transform.rotation, playerLayer);
        if (hit.Length == 1)
        {
            Animator playerAnimator = hit[0].GetComponent<Animator>();
            hit[0].GetComponent<HPManager>().LooseHP(1);
            playerAnimator.SetBool("receivesDamage", true);


        }
        attackAllowed = true;
        animator.SetBool("isAttacking", false);
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        Invoke("Damage", 1f);
    }
}