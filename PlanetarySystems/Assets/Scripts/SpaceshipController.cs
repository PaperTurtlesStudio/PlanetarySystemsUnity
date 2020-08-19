using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float ForwardSpeed = 25.0f;
    public float StrafeSpeed = 7.5f;
    public float HoverSpeed = 5.0f;
    public float MouseSensitivity = 90.0f;
    public float RollSpeed = 90.0f;

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
        MouseLook.x = Input.mousePosition.x;
        MouseLook.y = Input.mousePosition.y;

        MouseDistance.x = (MouseLook.x - ScreenCenter.x) / ScreenCenter.y;
        MouseDistance.y = (MouseLook.y - ScreenCenter.y) / ScreenCenter.y;

        MouseDistance = Vector2.ClampMagnitude(MouseDistance, 1.0f);

        Roll = Mathf.Lerp(Roll, Input.GetAxisRaw("Roll"), RollAcceleration * Time.deltaTime);

        transform.Rotate(-MouseDistance.y * MouseSensitivity * Time.deltaTime, MouseDistance.x * MouseSensitivity * Time.deltaTime, Roll * RollSpeed * Time.deltaTime, Space.Self);

        ActiveForwardSpeed = Mathf.Lerp(ActiveForwardSpeed, Input.GetAxisRaw("Vertical") * ForwardSpeed, ForwardAcceleration * Time.deltaTime);
        ActiveStrafeSpeed = Mathf.Lerp(ActiveStrafeSpeed, Input.GetAxisRaw("Horizontal") * StrafeSpeed, StrafeAcceleration * Time.deltaTime);
        ActiveHoverSpeed = Mathf.Lerp(ActiveHoverSpeed, Input.GetAxisRaw("Hover") * HoverSpeed, HoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * ActiveForwardSpeed * Time.deltaTime;
        transform.position += transform.right * ActiveStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * ActiveHoverSpeed * Time.deltaTime;
    }
}
