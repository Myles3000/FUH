using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class DialogueControl : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<string> dialogueLines;
    private int currentTaskIndex = 0;
    public static DialogueControl Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showCurrentTask();   
    }
    
    public void ProgressTask()
    {
        currentTaskIndex++;
        showCurrentTask();
    }

    void showCurrentTask()
    {
        if (currentTaskIndex < dialogueLines.Count)
        {
            text.text = dialogueLines[currentTaskIndex];
        }
        else
        {
            text.text = "All tasks completed!";
        }
    }
}
