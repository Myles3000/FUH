using UnityEngine;

public class NPCMuteInteraction : MonoBehaviour
{
    public KeyCode okKey = KeyCode.JoystickButton0;
    public KeyCode keyboardTestKey = KeyCode.E;

    [Header("Outline")]
    public Outline outline;
    public Color outlineColor = Color.yellow;
    public float outlineWidth = 4f;

    [Header("Audio To Mute/Unmute")]
    public AudioSource[] npcAudioSources;

    [Header("Audio Settings")]
    public float activeVolume = 1f;
    public float mutedVolume = 0f;
    public bool stopAudioWhenLookingAway = true;

    private bool interactionActive = false;

    void Start()
    {
        if (outline == null)
            outline = GetComponentInChildren<Outline>();

        if (outline != null)
        {
            outline.OutlineColor = outlineColor;
            outline.OutlineWidth = outlineWidth;
            outline.enabled = false;
        }

        MuteNPC();
    }

    void Update()
    {
        if (raycaster.ray == null)
            return;

        bool lookingAtThisNPC = raycaster.ray.LookingAt(transform);

        if (outline != null)
            outline.enabled = lookingAtThisNPC;

        if (lookingAtThisNPC && !interactionActive &&
            (Input.GetKeyDown(okKey) || Input.GetKeyDown(keyboardTestKey)))
        {
            UnmuteNPC();
        }

        if (interactionActive && !lookingAtThisNPC)
        {
            MuteNPC();
        }
    }

    void UnmuteNPC()
    {
        interactionActive = true;

        foreach (AudioSource source in npcAudioSources)
        {
            if (source != null)
            {
                source.enabled = true;
                source.mute = false;
                source.volume = activeVolume;
            }
        }

        Debug.Log("NPC unmuted: " + gameObject.name);
    }

    void MuteNPC()
    {
        interactionActive = false;

        foreach (AudioSource source in npcAudioSources)
        {
            if (source != null)
            {
                if (stopAudioWhenLookingAway)
                    source.Stop();

                source.volume = mutedVolume;
                source.mute = true;

                // Keep enabled because some Convai audio systems dislike disabled AudioSources.
                source.enabled = true;
            }
        }

        Debug.Log("NPC muted: " + gameObject.name);
    }
}