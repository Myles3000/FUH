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

    //cannon button pressed setters 
    public void MarkReadBook()
    {
        if (Consequences.Instance == null)
        {
            return;
        }

        Consequences.Instance.setreadBook(true);
    }

    public void MarkStoleCloth()
    {
        if (Consequences.Instance == null)
        {
            return;
        }

        Consequences.Instance.setStoleCloth(true);
    }


    public void MarkSilkRoadDecision()
    {

        if (Consequences.Instance == null)
        {
            return;
        }

        Consequences.Instance.setcanonSilkRoadChoice(true);
    }
}
