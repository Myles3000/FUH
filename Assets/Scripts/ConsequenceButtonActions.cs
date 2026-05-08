using UnityEngine;

public class ConsequenceButtonActions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MarkReadBook()
    {
        if (Consequences.Instance == null)
        {
            Debug.LogError("MarkReadBook failed: Consequences.Instance is NULL");
            return;
        }

        Consequences.Instance.setreadBook(true);
        Debug.Log("MarkReadBook through Instance. readBook = " + Consequences.Instance.getreadBook());
    }

    public void MarkStoleCloth()
    {
        if (Consequences.Instance == null)
        {
            Debug.LogError("MarkStoleCloth failed: Consequences.Instance is NULL");
            return;
        }

        Consequences.Instance.setStoleCloth(true);
        Debug.Log("MarkStoleCloth through Instance. stole_cloth = " + Consequences.Instance.getStoleCloth());
    }


    public void MarkSilkRoadDecision()
    {

        if (Consequences.Instance == null)
        {
            Debug.LogError("silk road failed: Consequences.Instance is NULL");
            return;
        }

        Consequences.Instance.setcanonSilkRoadChoice(true);
        Debug.Log("silkroad through Instance. stole_cloth = " + Consequences.Instance.getcanonSilkRoadChoice());
    }
}
