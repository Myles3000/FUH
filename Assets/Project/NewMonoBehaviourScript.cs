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
        
    }

    // Update is called once per frame
    void Update()
    {

        if (mainCamera == null || targetButton == null || Gamepad.current == null) return;

        RectTransform rect = targetButton.GetComponent<RectTransform>();
        Vector3 screenPos = mainCamera.WorldToScreenPoint(rect.position);

        bool isCentered =
            screenPos.z > 0 &&
            Mathf.Abs(screenPos.x - Screen.width / 2f) < centerRange &&
            Mathf.Abs(screenPos.y - Screen.height / 2f) < centerRange;

        ColorBlock colors = targetButton.colors;
        colors.normalColor = isCentered ? Color.yellow : Color.white;
        targetButton.colors = colors;

        if (isCentered && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            targetButton.onClick.Invoke();
        }
    }
    

}
