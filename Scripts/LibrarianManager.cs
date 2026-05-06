using UnityEngine;

public class LibrarianManager : MonoBehaviour
{
    public GameObject Conseq;
    public GameObject Dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuestComplete()
    {
        Conseq.GetComponent<Consequences>().setHasBook(true);
        Dialogue.GetComponent<DialogueControl>().ProgressTask();
    }
}
