using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 25f;
    public float gravity = -9.81f;
    public float jumpHeight = 8.25f;
    
    public float jumpBoost = 1.2f;
    public GameObject Crystal;
    public Transform groundCheck;
    public float groundDistance = 2.2f;
    public LayerMask groundMask;
    public bool isGrounded;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && Crystal.activeInHierarchy == false)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Crystal.activeInHierarchy == true && jumpHeight < 9.9f)
        {
            jumpHeight = jumpHeight * jumpBoost;
        }
        if (Input.GetButtonDown("Jump") && isGrounded && Crystal.activeInHierarchy == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
