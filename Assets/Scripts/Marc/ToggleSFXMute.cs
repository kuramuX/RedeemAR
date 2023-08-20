using UnityEngine;
using UnityEngine.UI;

public class ToggleSFXMute : MonoBehaviour
{
    public Toggle toggle;
    public AudioSource SFX;

    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isMuted)
    {

        if (isMuted)
        {
            SFX.volume = 1f; // Set volume back to full when toggle is checked (not muted).

        }
        else
        {
            SFX.volume = 0f; // Set volume to 0 when toggle is unchecked (muted).

        }
    }
}
