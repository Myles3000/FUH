using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class OpeningScene : MonoBehaviour
{

    public string scene;
    
    public TMP_Text error;
    public float errorShowTime = 10f;
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
        SceneManager.LoadScene(scene);
    }


}