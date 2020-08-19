using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator Animator;
    public Transform PlayerModel;
    public Transform PlayerCamera;
    public CharacterController PlayerController;
    public Transform GroundCheck;
    public LayerMask GroundMask;

    public float PlayerSpeed = 3.0f;
    public float TurnSmoothTime = 0.1f;
    public float Gravity = -9.8f;
    public float GroundDistance = 0.2f;
    public float JumpHeight = 3.0f;
    
    float TurnSmoothVelocity;
    Vector3 Velocity;
    bool BIsGrounded;
    bool BCanJump;

    // Update is called once per frame
    void Update()
    {
        BIsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (BIsGrounded) { BCanJump = true; }

        if(BIsGrounded && Velocity.y < 0) { Velocity.y = -2.0f; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);
        PlayerModel.position = gameObject.transform.position;
        PlayerController.Move(move * PlayerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            if (BCanJump)
            {
                Velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * Gravity);
            }
        }

        Velocity.y += Gravity * Time.deltaTime;
        PlayerController.Move(Velocity * Time.deltaTime);
    }
}
