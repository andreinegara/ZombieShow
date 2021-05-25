using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 100f;

    public float forwardSpeed = 3f;
    public float backwardsSpeed = 1.5f;
    public float jumpStrength = 300f;

    private Animator animator;
    private Rigidbody rb;
    private bool onGround;
    private bool allowDoubleJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Walk();
        

        //Jumping Conditions

        if(Input.GetKeyDown(KeyCode.Space)){
            if (onGround)
            {
                Jump();

                allowDoubleJump = true;

            }

            else if (allowDoubleJump)
            {
                Jump();
                allowDoubleJump = false;
            }
            
        }
        else
            animator.SetBool("isJumping",false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Plane")
        {
            onGround = true;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Plane")
        {
            onGround = false;
        }
    }


    void Walk()
    {
        float verticalArrow = Input.GetAxis("Vertical");
        //Walking Conditions
        if (verticalArrow > 0)
        {
            animator.SetBool("Running", true);
            animator.SetFloat("Speed", 1f);
            transform.Translate(0f, 0f, forwardSpeed * verticalArrow * Time.deltaTime);
            transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        else if (verticalArrow < 0)
        {
            animator.SetBool("Running", true);
            animator.SetFloat("Speed", -0.6f);
            transform.Translate(0f, 0f, backwardsSpeed * verticalArrow * Time.deltaTime);
            transform.Rotate(Vector3.down * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        else
        {
            animator.SetBool("Running", false);
            transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpStrength);
        animator.SetBool("isJumping", true);
    }

}
