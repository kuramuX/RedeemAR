using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioMute : MonoBehaviour
{
    public Toggle toggle;
    public AudioSource BGM;
    public AudioSource Environment;

    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isMuted)
    {

        if (isMuted)
        {
            BGM.volume = 1f; // Set volume back to full when toggle is checked (not muted).
            Environment.volume = 1f; // Set volume back to full when toggle is checked (not muted).
        }
        else
        {
            BGM.volume = 0f; // Set volume to 0 when toggle is unchecked (muted).
            Environment.volume = 0f; // Set volume to 0 when toggle is unchecked (muted).
        }
    }
}
