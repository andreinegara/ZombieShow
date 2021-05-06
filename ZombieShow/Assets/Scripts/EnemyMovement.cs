using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float walkingSpeed;
    public float minimumDistance;
    public CharacterController controller;
    public Animator animator;

    //Directing it will be heading
    public string aimName;
    private Transform aim;


    // Start is called before the first frame update
    void Start()
    {
        aim = GameObject.Find(aimName).transform;
    }

    void Follow()
    {
        transform.LookAt(aim.position);
        controller.SimpleMove(transform.forward * walkingSpeed);
        animator.SetBool("isWalking", true);
    }
    // Update is called once per frame
    void Update()
    {
        //will only follow in case of a minimum distance between Enemy and Player
        if (Vector3.Distance (transform.position, aim.position)>= minimumDistance)
        {
            Follow();
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
