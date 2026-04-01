<<<<<<< HEAD
using UnityEngine;

public class raycaster : MonoBehaviour
{
    public static raycaster ray;
    public Camera mainCam;
    public float distance = 4f;
    public RaycastHit hit;
    public bool hasHit;

    public bool interactable = true;

    [Header("Visible Ray")]
    public LineRenderer lineRenderer;
    public bool showRayLine = true;

    void Awake()
    {
        ray = this;
        if (mainCam == null)
            mainCam = Camera.main;
    }

    //if object != interactable then ignore hit
    void Update()
    {
        if (!interactable)
        {
            hasHit = false;


            if (lineRenderer != null)
                lineRenderer.enabled = false;

            return;
        }
        hasHit = Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, distance);

        UpdateRayLine();
    }

    //to check if camera is looking at interactable object 
    public bool LookingAt(Transform target)
    {
        return interactable && hasHit && hit.transform.IsChildOf(target);
    }

    //a fialed attempt at getting the ray line in front of camera 
    void UpdateRayLine()
    {
        if (lineRenderer == null || mainCam == null) return;

        lineRenderer.enabled = showRayLine;
        if (!showRayLine) return;

        Vector3 forward = mainCam.transform.forward.normalized;

        //should show the line in front of camera
        Vector3 start = mainCam.transform.position + forward * 1f;
        Vector3 end;

        if (hasHit)
        {
            end = hit.point;
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
        else
        {
            end = start + forward * distance;
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
        }

        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
=======
using UnityEngine;

public class raycaster : MonoBehaviour
{
    public static raycaster ray;
    public Camera mainCam;
    public float distance = 4f;
    public RaycastHit hit;
    public bool hasHit;

    public bool interactable = true;

    [Header("Visible Ray")]
    public LineRenderer lineRenderer;
    public bool showRayLine = true;

    void Awake()
    {
        ray = this;
        if (mainCam == null)
            mainCam = Camera.main;
    }

    //if object != interactable then ignore hit
    void Update()
    {
        if (!interactable)
        {
            hasHit = false;


            if (lineRenderer != null)
                lineRenderer.enabled = false;

            return;
        }
        hasHit = Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, distance);

        UpdateRayLine();
    }

    //to check if camera is looking at interactable object 
    public bool LookingAt(Transform target)
    {
        return interactable && hasHit && hit.transform.IsChildOf(target);
    }

    //a fialed attempt at getting the ray line in front of camera 
    void UpdateRayLine()
    {
        if (lineRenderer == null || mainCam == null) return;

        lineRenderer.enabled = showRayLine;
        if (!showRayLine) return;

        Vector3 forward = mainCam.transform.forward.normalized;

        //should show the line in front of camera
        Vector3 start = mainCam.transform.position + forward * 1f;
        Vector3 end;

        if (hasHit)
        {
            end = hit.point;
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
        else
        {
            end = start + forward * distance;
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
        }

        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
>>>>>>> 1c2e232bab00270c269c0fa4d02fe2a71675d144
}