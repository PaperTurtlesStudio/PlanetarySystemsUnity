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
    Vector3 CrouchCamera = new Vector3(0f, 1.2f, 0.35f);
    Vector3 IdleCamera = new Vector3(0f, 1.5f, 0f);

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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Animator.SetBool("BIsCrouch", true);
            PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, CrouchCamera, 5.0f * Time.deltaTime);
        }
        else
        {
            Animator.SetBool("BIsCrouch", false);
            PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, IdleCamera, 5.0f * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("BIsWalking", true);
        }
        else
        {
            Animator.SetBool("BIsWalking", false);
        }

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
