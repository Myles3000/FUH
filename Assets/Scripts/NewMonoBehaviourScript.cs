using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera mainCamera;
    public Button targetButton;
    public float centerRange = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if null, just return 
        if (mainCamera == null || targetButton == null || Gamepad.current == null) 
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

        //trigger onClick to switch screens 
        if (isAtCenter && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            targetButton.onClick.Invoke();
        }
    }
    

}
