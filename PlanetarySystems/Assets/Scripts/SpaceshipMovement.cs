using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public Transform SpaceshipModel;
    public Transform SpaceshipCamera;
    public CharacterController SpaceshipController;

    public float InitialSpeed = 100.0f;
    public float MiddleSpeed = 1000.0f;
    public float MaxSpeed = 5000.0f;

    float SpaceshipSpeed;

    private void Start()
    {
        SpaceshipSpeed = InitialSpeed;
    }

    private void Update()
    {
        //if thrust is hit go to next highest speed
        if (Input.GetKey(KeyCode.W) )
        {
            if(SpaceshipSpeed == InitialSpeed)
            {
                SpaceshipSpeed = MiddleSpeed;
            }
            else if (SpaceshipSpeed == MiddleSpeed)
            {
                SpaceshipSpeed = MiddleSpeed;
            }
        }

        //if brakes are hit, go to next lowest speed
        if (Input.GetKey(KeyCode.S))
        {
            if (SpaceshipSpeed == MaxSpeed)
            {
                SpaceshipSpeed = MiddleSpeed;
            }
            else if(SpaceshipSpeed == MiddleSpeed)
            {
                SpaceshipSpeed = InitialSpeed;
            }
        }

        Debug.Log(SpaceshipSpeed);

        Vector3 move = transform.forward;
        SpaceshipModel.position = gameObject.transform.position;
        SpaceshipController.Move(move * SpaceshipSpeed * Time.deltaTime);

        //mouse controls where spaceship is looking/which way is forward


    }
}
