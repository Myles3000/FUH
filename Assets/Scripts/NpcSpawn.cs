using UnityEngine;

public class NpcSpawn : MonoBehaviour
{
    public GameObject spawn;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawn != null)
        {
            Instantiate(spawn, transform.position, transform.rotation);
        }
    }
}
