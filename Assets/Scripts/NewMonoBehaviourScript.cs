using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera mainCamera;
    public Button targetButton;
    public float centerRange = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if null, just return 
        if (mainCamera == null || targetButton == null)
            return;

        //get recttansform for button
        RectTransform rect = targetButton.GetComponent<RectTransform>();


        //button's wold postion are converted into screen postions --> for button location comparison 
        Vector3 screenPos = mainCamera.WorldToScreenPoint(rect.position);

        //cehcking if the button is at the center or close 
        bool isAtCenter =
            screenPos.z > 0 &&
            Mathf.Abs(screenPos.x - Screen.width / 2f) < centerRange &&
            Mathf.Abs(screenPos.y - Screen.height / 2f) < centerRange;

        if (!isAtCenter)
            return;

        bool pressed = false;

        //new version
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            pressed = true;

        //trigger onClick to switch screens 
        //    if (isAtCenter && Gamepad.current.buttonSouth.wasPressedThisFrame)
        //    {
        //        targetButton.onClick.Invoke();
        //    }
        //}

        //old version
        if (Input.GetKeyDown(KeyCode.JoystickButton0) ||
            Input.GetKeyDown(KeyCode.JoystickButton1) ||
            Input.GetKeyDown(KeyCode.JoystickButton8) ||
            Input.GetKeyDown(KeyCode.JoystickButton10) ||
            Input.GetKeyDown(KeyCode.E))
        {
            pressed = true;
        }

        if (pressed)
        {
            Debug.Log("Invoking UI button: " + targetButton.name);
            targetButton.onClick.Invoke();
        }


    }
}