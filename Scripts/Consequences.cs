using UnityEngine;

public class Consequences : MonoBehaviour
{
    private bool hasBook = false;
    private bool rob_gen = false;
    private bool stole_cloth = false;
    private bool canonChoice = false;

    public int consequence()
    {
        if (canonChoice)
        {
            if (rob_gen && stole_cloth)
            {
                return 2;
            }
            else if (rob_gen)
            {
                return 3;
            }
            else if (stole_cloth)
            {
                return 1;
            }
        }
        return 0;

    }
    public bool getHasBook()
    {
        return hasBook;
    }

    public void setHasBook(bool value)
    {
        hasBook = value;
    }

    public void setRobGen(bool value)
    {
        rob_gen = value;
    }

    public void setStoleCloth(bool value)
    {
        stole_cloth = value;
    }
}
