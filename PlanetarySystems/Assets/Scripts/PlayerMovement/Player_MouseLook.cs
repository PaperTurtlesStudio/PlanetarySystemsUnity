using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	public Transform playerBody;
	
	private float xRotation = 0f;

	public Interactable Interactable;
	Camera Camera;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		Camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		MouseLookAround();
		MousePressPickUp();
	}

	void MouseLookAround()
    {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xRotation -= mouseY;

		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}

	void MousePressPickUp()
    {
		if(EventSystem.current.IsPointerOverGameObject()) { return; }

        if (Input.GetMouseButtonDown(0))
        {
			Ray Ray = Camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit Hit;

			if(Physics.Raycast(Ray, out Hit, 100))
            {
				Interactable = Hit.collider.GetComponent<Interactable>();
				if(Interactable != null)
                {
					Interactable.Interact();
                }
            }
        }
    }
}
