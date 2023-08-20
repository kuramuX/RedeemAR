using UnityEngine;
using UnityEngine.UI;

public class PlaySFXOnClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sfxClip;

    private Button button;

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(PlaySFX);
    }

    private void PlaySFX()
    {
        // Play the specified audio clip
        audioSource.PlayOneShot(sfxClip);
    }
}
