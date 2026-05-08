using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueControl : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<string> dialogueLines;
    private int currentTaskIndex = 0;
   
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
