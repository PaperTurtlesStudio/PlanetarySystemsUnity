using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Animator Animator;
    public Transform PlayerModel;
    public Transform PlayerCamera;
    public CharacterController PlayerController;
    public Transform GroundCheck;
    public LayerMask GroundMask;

    public float WalkingSpeed = 3.0f;
    public float RunningSpeed = 6.0f;
    public float CrouchSpeed = 1.0f;
    public float TurnSmoothTime = 0.1f;
    public float Gravity = -9.8f;
    public float GroundDistance = 0.2f;
    public float JumpHeight = 3.0f;

    float PlayerSpeed;
    float TurnSmoothVelocity;
    Vector3 Velocity;
    bool BIsGrounded;
    bool BCanJump;
    bool BThirdPerson = false;
    Vector3 FirstPersonCrouchCamera = new Vector3(0f, 1.2f, 0.35f);
    Vector3 ThirdPersonCrouchCamera = new Vector3(0.0f, 1.5f, -1.35f);
    Vector3 FirstPersonCamera = new Vector3(0f, 1.5f, 0f);
    Vector3 ThirdPersonCamera = new Vector3(0.0f, 1.8f, -1.0f);

    private void Start()
    {
        PlayerSpeed = WalkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CameraPOV();
        CrouchControl();
        WalkingControl();
        Jump();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerSpeed = RunningSpeed;
        }
        else
        {
            PlayerSpeed = WalkingSpeed;
        }

        Vector3 move = (transform.right * x) + (transform.forward * z);
        PlayerModel.position = gameObject.transform.position;
        PlayerController.Move(move * PlayerSpeed * Time.deltaTime);
    }

    void CameraPOV()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (BThirdPerson)
            {
                PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, ThirdPersonCamera, 5.0f);
                BThirdPerson = false;
            }
            else
            {
                PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, FirstPersonCamera, 5.0f);
                BThirdPerson = true;
            }
        }
    }

    void Jump()
    {
        BIsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (BIsGrounded) { BCanJump = true; }

        if (BIsGrounded && Velocity.y < 0) { Velocity.y = -2.0f; }

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

    void CrouchControl()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayerSpeed = CrouchSpeed;
            Animator.SetBool("BIsCrouch", true);

            if (BThirdPerson)
            {
                PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, ThirdPersonCrouchCamera, 5.0f * Time.deltaTime);
            }
            else
            {
                PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, FirstPersonCrouchCamera, 5.0f * Time.deltaTime);
            }

            //Add in here for when character is moving
        }
        else
        {
            PlayerSpeed = WalkingSpeed;
            Animator.SetBool("BIsCrouch", false);

            if (BThirdPerson)
            {
                PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, ThirdPersonCamera, 5.0f * Time.deltaTime);
            }
            else
            {
                PlayerCamera.localPosition = Vector3.Lerp(PlayerCamera.localPosition, FirstPersonCamera, 5.0f * Time.deltaTime);
            }
        }
    }

    void WalkingControl()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("BIsWalking", true);
            //Add in Running Control right here
        }
        else
        {
            Animator.SetBool("BIsWalking", false);
        }
    }
}