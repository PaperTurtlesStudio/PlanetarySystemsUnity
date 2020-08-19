using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour
{
    public GameObject SpaceshipModel;
    public Image SpaceshipFirstPerson;
    public Transform SpaceshipCamera;

    public float ForwardSpeed = 25.0f;
    public float StrafeSpeed = 7.5f;
    public float HoverSpeed = 5.0f;
    public float MouseSensitivity = 90.0f;
    public float RollSpeed = 90.0f;
    public float InitialSpeed = 1.0f;

    private float ActiveForwardSpeed;
    private float ActiveStrafeSpeed;
    private float ActiveHoverSpeed;
    private float ForwardAcceleration = 2.5f;
    private float StrafeAcceleration = 2.0f;
    private float HoverAcceleration = 2.0f;
    private Vector2 MouseLook;
    private Vector2 ScreenCenter;
    private Vector2 MouseDistance;
    private float Roll;
    private float RollAcceleration = 3.5f;
    private bool BThirdPerson = true;




    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        ScreenCenter.x = Screen.width * 0.5f;
        ScreenCenter.y = Screen.height * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        SpaceshipMovement();


        if (Input.GetKeyDown(KeyCode.C))
        {
            if (BThirdPerson)
            {
                SpaceshipFirstPerson.gameObject.SetActive(false);
                SpaceshipModel.SetActive(true);

                SpaceshipCamera.localPosition = new Vector3(0.0f, 13.0f, -30.0f);
                SpaceshipCamera.localRotation = Quaternion.Euler(11.0f, 0.0f, 0.0f);

                BThirdPerson = false;
            }
            else
            {
                SpaceshipFirstPerson.gameObject.SetActive(true);
                SpaceshipModel.SetActive(false);

                SpaceshipCamera.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                SpaceshipCamera.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

                BThirdPerson = true;
            }
        }
        
    }

    void SpaceshipMovement()
    {
        MouseLook.x = Input.mousePosition.x;
        MouseLook.y = Input.mousePosition.y;

        MouseDistance.x = (MouseLook.x - ScreenCenter.x) / ScreenCenter.y;
        MouseDistance.y = (MouseLook.y - ScreenCenter.y) / ScreenCenter.y;

        MouseDistance = Vector2.ClampMagnitude(MouseDistance, 1.0f);

        Roll = Mathf.Lerp(Roll, Input.GetAxisRaw("Roll"), RollAcceleration * Time.deltaTime);

        transform.Rotate(-MouseDistance.y * MouseSensitivity * Time.deltaTime, MouseDistance.x * MouseSensitivity * Time.deltaTime, Roll * RollSpeed * Time.deltaTime, Space.Self);

        ActiveForwardSpeed = Mathf.Lerp(ActiveForwardSpeed, (Input.GetAxisRaw("Vertical") + InitialSpeed) * ForwardSpeed, ForwardAcceleration * Time.deltaTime);
        ActiveStrafeSpeed = Mathf.Lerp(ActiveStrafeSpeed, (Input.GetAxisRaw("Horizontal") + InitialSpeed) * StrafeSpeed, StrafeAcceleration * Time.deltaTime);
        ActiveHoverSpeed = Mathf.Lerp(ActiveHoverSpeed, (Input.GetAxisRaw("Hover") + InitialSpeed) * HoverSpeed, HoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * ActiveForwardSpeed * Time.deltaTime;
        transform.position += transform.right * ActiveStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * ActiveHoverSpeed * Time.deltaTime;
    }


}
