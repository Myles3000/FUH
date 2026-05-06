using UnityEngine;

public class NPCInteractions : MonoBehaviour
{


    public KeyCode okKey = KeyCode.JoystickButton0;
    public KeyCode keyboardTestKey = KeyCode.E;

    public Animator animator;
    public string talkAnimationTrigger = "Talk";


    public MonoBehaviour convaiCharacterScript;
    public AudioSource audioSource;

    private bool hasStartedTalking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        // Keep speech/audio off until the player chooses this NPC.
        if (audioSource != null)
            audioSource.enabled = false;

        // Optional: if your Convai character talks automatically, keep it disabled first.
        if (convaiCharacterScript != null)
            convaiCharacterScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (raycaster.ray == null)
            return;

        bool lookingAtThisNPC = raycaster.ray.LookingAt(transform);

        if (lookingAtThisNPC && (Input.GetKeyDown(okKey) || Input.GetKeyDown(keyboardTestKey)))
        {
            EnableTalking();
        }
    }

    public void EnableTalking()
    {
        if (hasStartedTalking)
            return;

        hasStartedTalking = true;

        if (convaiCharacterScript != null)
            convaiCharacterScript.enabled = true;

        if (audioSource != null)
            audioSource.enabled = true;

        if (animator != null && !string.IsNullOrEmpty(talkAnimationTrigger))
            animator.SetTrigger(talkAnimationTrigger);
    }

    public void StopTalking()
    {
        hasStartedTalking = false;

        if (audioSource != null)
            audioSource.enabled = false;

        if (convaiCharacterScript != null)
            convaiCharacterScript.enabled = false;
    }
}
