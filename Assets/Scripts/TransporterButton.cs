using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TransporterButton : MonoBehaviour
{
    public static TransporterButton Instance;

    public KeyCode keyboardTestKey = KeyCode.E;

    private bool isLoading = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isLoading = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //button A used to transport to the modified/unmodified present 
        KeyCode windowsA = (KeyCode)((int)KeyCode.JoystickButton0 + 8);
        KeyCode androidA = (KeyCode)((int)KeyCode.JoystickButton0 + 10);

        if (Input.GetKeyDown(windowsA) ||
            Input.GetKeyDown(androidA) ||
            Input.GetKeyDown(keyboardTestKey))
        {
            Transport();
        }
    }

    //transport based on the button choices 
    public void Transport()
    {
        if (isLoading)
            return;

        if (Consequences.Instance == null)
        {
            return;
        }

        isLoading = true;
        Consequences.Instance.LoadPresentScene();
    }

}
