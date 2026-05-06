using UnityEngine;

public class Cannno : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickCanonChoice()
    {
        Consequences.Instance.setcanonSilkRoadChoice(true);
    }
}
