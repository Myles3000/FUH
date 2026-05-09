using UnityEngine;
using UnityEngine.UI;

public class ButtonOutliner : MonoBehaviour
{

    public Camera cam;
    public float range = 300f;
    public Color normal = Color.white;
    public Color highlight = Color.yellow;

    Image img;
    RectTransform rect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        if (cam == null) cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null)
            FindCamera();

        if (cam == null || img == null || rect == null)
            return;

        Vector3 pos = cam.WorldToScreenPoint(rect.position);

        bool looking =
            pos.z > 0 &&
            Mathf.Abs(pos.x - Screen.width / 2f) < range &&
            Mathf.Abs(pos.y - Screen.height / 2f) < range;

        img.color = looking ? highlight : normal;
    }

    void FindCamera()
    {
        cam = Camera.main;
    }
}
