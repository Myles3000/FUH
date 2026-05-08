using UnityEngine;
using UnityEngine.SceneManagement;

public class Consequences : MonoBehaviour
{
    public static Consequences Instance;

    private bool readBook = false;
    private bool rob_gen = false;
    private bool stole_cloth = false;
    private bool canonSilkRoadChoice = false;
    public GameObject openCourt;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void setreadBook(bool value)
    {
        readBook = value;
    }

    public void setRobGen(bool value)
    {
        rob_gen = value;
    }

    public void setStoleCloth(bool value)
    {
        stole_cloth = value;
    }

    public void setcanonSilkRoadChoice(bool value)
    {
        canonSilkRoadChoice = value;
    }

    public bool getreadBook()
    {
        return readBook;
    }

    public bool getRobGen()
    {
        return rob_gen;
    }

    public bool getStoleCloth()
    {
        return stole_cloth;
    }

    public bool getcanonSilkRoadChoice()
    {
        return canonSilkRoadChoice;
    }

    //checking each/combination button's status 
    public int consequence()
    {
        
        if ((readBook && stole_cloth && canonSilkRoadChoice) || canonSilkRoadChoice)
        {
            return 2;
        }
        else if ((rob_gen && stole_cloth && readBook) || readBook || stole_cloth || rob_gen)
        {
            return 1;
        }
        

        return 0;
    }

    //scene openers per decision/consequence 
    public void LoadPresentScene()
    {
        int result = consequence();

        if (result == 0)
        {
            SceneManager.LoadScene("Apartment");
        }
        else if (result == 1)
        {
            SceneManager.LoadScene("LuxuryApartment");
        }
        else if (result == 2)
        {
            SceneManager.LoadScene("BadApartment");
        }
        
    }

    //check the status of each button 
    public void StatusCheck()
    {
        if (!readBook && !rob_gen && !stole_cloth && !canonSilkRoadChoice)
        {
            Debug.Log("You have not made a choice, you cannot return to the present");
        }

        if (!readBook || !stole_cloth)
        {
            Debug.Log("You have not met the requirements to enter the palace: read the book and steal the minister's cloth");
        }
    }


  
    

    public void OpenCourtBallet()
    {
        if (readBook && stole_cloth)
        {
            openCourt.SetActive(false);
        }
    }
}