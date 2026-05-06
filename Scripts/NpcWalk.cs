using UnityEngine;

public class NpcWalk : MonoBehaviour
{
    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
