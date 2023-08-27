using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterClick : MonoBehaviour
{
    public Image imageToUpdate; // Reference to the UI Image component to update
    public Sprite boySprite;     // Reference to the sprite for the "boy" button
    public Sprite girlSprite;    // Reference to the sprite for the "girl" button
    public Sprite robotSprite;   // Reference to the sprite for the "robot" button

    private void Start()
    {
        // Set the initial sprite of the image (optional)
        imageToUpdate.sprite = boySprite;
    }

    public void OnButtonClick(string buttonName)
    {
        switch (buttonName)
        {
            case "boy":
                imageToUpdate.sprite = boySprite;
                PlayerPrefs.SetString("Character", "boy");
                break;
            case "girl":
                imageToUpdate.sprite = girlSprite;
                PlayerPrefs.SetString("Character", "girl");
                break;
            case "robot":
                imageToUpdate.sprite = robotSprite;
                PlayerPrefs.SetString("Character", "robot");
                break;
            default:
                Debug.LogWarning("Unknown button name: " + buttonName);
                break;
        }
    }
}
