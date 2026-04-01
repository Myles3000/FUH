<<<<<<< HEAD
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

=======
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

>>>>>>> 1c2e232bab00270c269c0fa4d02fe2a71675d144
}