using UnityEngine;

public class ConvaiDestroyer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] objects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in objects)
        {
            bool isPersistentObject = obj.scene.name == "DontDestroyOnLoad";

            if (isPersistentObject &&
                (obj.name.Contains("ConvaiManager") || obj.name.Contains("LiveKitSDK")))
            {
                Debug.Log("Destroying old persistent Convai object: " + obj.name);
                Destroy(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
