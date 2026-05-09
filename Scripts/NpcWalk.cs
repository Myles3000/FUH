using UnityEngine;

public class NpcWalk : MonoBehaviour
{
    public float speed = 2.0f;
    void Start()
    {
        // Optionally, you can initialize any variables or states here
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
