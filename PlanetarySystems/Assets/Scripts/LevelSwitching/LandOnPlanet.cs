using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandOnPlanet : MonoBehaviour
{
    public Spaceship_MovementController Spaceship;

    private bool BLanding = false;
    private string LandingPlanet;

    // Update is called once per frame
    void Update()
    {
        if (BLanding)
        {
            //Bring up options UI (ZipCom)

            if (Input.GetKey(KeyCode.L))
            {
                Debug.Log("Loading Scene");
                SceneManager.LoadScene(LandingPlanet);
            }
            else if (Input.GetKey(KeyCode.B))
            {
                Spaceship.ForwardSpeed = 75.0f;
                Spaceship.StrafeSpeed = 7.5f;
                Spaceship.HoverSpeed = 5.0f;
                Spaceship.MouseSensitivity = 45.0f;
                Spaceship.RollSpeed = 90.0f;

                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

                BLanding = false;
                LandingPlanet = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BLanding = true;
        LandingPlanet = other.name;

        //stop all movement/input
        Spaceship.ForwardSpeed = 0.0f;
        Spaceship.StrafeSpeed = 0.0f;
        Spaceship.HoverSpeed = 0.0f;
        Spaceship.MouseSensitivity = 0.0f;
        Spaceship.RollSpeed = 0.0f;
    }   
}

