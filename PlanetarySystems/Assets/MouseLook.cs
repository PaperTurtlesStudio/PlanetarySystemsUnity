using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivity = 100.0f;
    public Transform PlayerBody;
    float xRotation = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        if (mouseY < 0.1 && mouseY > -0.1)
        {
            mouseY = 0;
        }
        if (mouseX < 0.1 && mouseX > -0.1)
        {
            mouseX = 0;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
