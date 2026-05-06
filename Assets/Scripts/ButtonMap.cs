using UnityEngine;
using UnityEngine.UI;

public class ButtonMap : MonoBehaviour
{
    public Button buttonToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode windowsOK = (KeyCode)((int)KeyCode.JoystickButton0 + 3);
        KeyCode androidOK = (KeyCode)((int)KeyCode.JoystickButton0);

        bool pressedOK =
            Input.GetKeyDown(windowsOK) ||
            Input.GetKeyDown(androidOK) ||
            Input.GetKeyDown(KeyCode.E);

        if (!pressedOK)
            return;

        if (raycaster.ray != null && raycaster.ray.LookingAt(transform))
        {

            if (buttonToPress != null)
                buttonToPress.onClick.Invoke();
        }
    }
}
