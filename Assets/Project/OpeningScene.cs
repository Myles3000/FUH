using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{

    public string start;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //scene loader script to load next scene (opening scene)
    public void NextScene()
    {
        SceneManager.LoadScene(start);
    }
}
