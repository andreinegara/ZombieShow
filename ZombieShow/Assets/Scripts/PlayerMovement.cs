using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float turnSpeed = 100f;
    float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
