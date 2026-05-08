using UnityEngine;
using UnityEngine.SceneManagement;

public class Consequences : MonoBehaviour
{
    public static Consequences Instance;

    private bool readBook = false;
    private bool rob_gen = false;
    private bool stole_cloth = false;
    private bool canonSilkRoadChoice = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate Consequences destroyed: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("Consequences Instance is: " + gameObject.name);
    }

    public void setreadBook(bool value)
    {
        readBook = value;
        Debug.Log("setreadBook called. readBook = " + readBook + " on " + gameObject.name);
    }

    public void setRobGen(bool value)
    {
        rob_gen = value;
    }

    public void setStoleCloth(bool value)
    {
        stole_cloth = value;
        Debug.Log("setStoleCloth called. stole_cloth = " + stole_cloth + " on " + gameObject.name);
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

    public bool AllRequiredButtonsClicked()
    {
        return readBook && rob_gen && stole_cloth && canonSilkRoadChoice;
    }

    public bool OpenCourt()
    {
        Debug.Log(
        "OpenCourt check on " + gameObject.name +
        ": readBook = " + readBook +
        ", stole_cloth = " + stole_cloth
        );

        return readBook && stole_cloth;
    }

    public int consequence()
    {
        if (canonSilkRoadChoice)
        {
            if (readBook && stole_cloth && canonSilkRoadChoice)
            {
                return 2;
            }
            else if ((rob_gen && stole_cloth && readBook) || readBook || stole_cloth || rob_gen)
            {
                return 1;
            }
        }

        return 0;
    }


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

    public void TrySwitchScene(string sceneName)
    {
        if (AllRequiredButtonsClicked())
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void StatusCheck()
    {
        if (readBook && rob_gen && stole_cloth && canonSilkRoadChoice == false)
        {
            Debug.Log("You have not made a choice, you cannot return to the present");
        }

        if (readBook || stole_cloth == false)
        {
            Debug.Log("You have not met the requirements to enter the palace: read the book and steal the minister's cloth");
        }
    }
}