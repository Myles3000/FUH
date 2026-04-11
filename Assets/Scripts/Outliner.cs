using UnityEngine;


public class Outliner : MonoBehaviour
{
   
    public Outline outline;

    void Start()
    {
        //get outline
        if (!outline) outline = GetComponent<Outline>();

        //keep outline off until something has been hit 
        if (outline) outline.enabled = false;
    }

    void Update()
    {
        //if ray hits object, turn on highlighter 
        if (outline)
            outline.enabled = raycaster.ray && raycaster.ray.LookingAt(transform);
    }
}