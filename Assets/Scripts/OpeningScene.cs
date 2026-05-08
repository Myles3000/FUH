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
        if (Consequences.Instance == null)
        {
            DisplayError("Consequences manager is missing.");
            Debug.LogWarning("Consequences.Instance is missing.");
            return;
        }

        bool canOpen = Consequences.Instance.OpenCourt();

        Debug.Log("Court button pressed. Can open court = " + canOpen);



        if (!canOpen)
        {
            Consequences.Instance.StatusCheck();
            return;
        }

        string sceneName = scene.Trim();

        Debug.Log("Trying to load scene: " + sceneName);
        Debug.Log("CanStreamedLevelBeLoaded: " + Application.CanStreamedLevelBeLoaded(sceneName));

        SceneManager.LoadScene(sceneName);
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