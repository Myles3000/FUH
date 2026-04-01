using UnityEngine;

public class OpenSeseme : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode windowsOK = (KeyCode)((int)KeyCode.JoystickButton0 + 3);
        KeyCode androidOK = (KeyCode)((int)KeyCode.JoystickButton0);

        //Buttons for Myles, currently OK button does not work
        //KeyCode windowsOKM = (KeyCode)((int)KeyCode.JoystickButton0 + 2);
        //KeyCode androidOKM = (KeyCode)((int)KeyCode.JoystickButton0 + 1);

        if (Input.GetKeyDown(windowsOK) || Input.GetKeyDown(androidOK))
        {
            //check that button is clicked while look at obj
            if (raycaster.ray != null && raycaster.ray.hasHit)
            {
                OpeningScene button = raycaster.ray.hit.transform.GetComponentInParent<OpeningScene>();

                //open sesame 
                if (button != null)
                {
                    button.NextScene();
                }
            }
        }
    }
}
