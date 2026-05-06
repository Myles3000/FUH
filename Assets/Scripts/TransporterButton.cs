using UnityEngine;
using UnityEngine.UI;
public class TransporterButton : MonoBehaviour
{
    public Button targetButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        KeyCode windowsA = (KeyCode)((int)KeyCode.JoystickButton0 + 8);
        KeyCode androidA = (KeyCode)((int)KeyCode.JoystickButton0 + 10);

        if (Input.GetKeyDown(windowsA) || Input.GetKeyDown(androidA) || Input.GetKeyDown(KeyCode.E))
        {
            ButtonPressed();
        }
    }

    public void ButtonPressed()
    {
        if (Consequences.Instance == null)
        {
            return;
        }

        // Change this to whatever prerequisite you need
        if (Consequences.Instance.AllRequiredButtonsClicked())
        {
            if (targetButton != null)
            {
                targetButton.onClick.Invoke();
            }
        }
        else
        {
            Consequences.Instance.StatusCheck();
        }
    }
}
