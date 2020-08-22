using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToSpace : MonoBehaviour
{
    public GameObject Spaceship;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Spaceship.transform.position, transform.position) < 20.0f && Input.GetKey(KeyCode.L))
        {
            Debug.Log("Changing Scenes");

            SceneManager.LoadScene("L_SpaceBlocking");
        }
        else if(Input.GetKey(KeyCode.L))
        {
               
        }
    }
}
