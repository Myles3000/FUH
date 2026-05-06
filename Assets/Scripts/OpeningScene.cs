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

    public void court()
    {
        if (Consequences.Instance.OpenCourt())
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Consequences.Instance.StatusCheck();
        }
    }

    private void DisplayError(string message)
    {
        if (error == null)
        {
            Debug.LogWarning(message);
            return;
        }

        error.text = message;
        error.gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HideErrorAfterDelay());
    }

    private IEnumerator HideErrorAfterDelay()
    {
        yield return new WaitForSeconds(errorShowTime);

        if (error != null)
        {
            error.gameObject.SetActive(false);
        }
    }
}