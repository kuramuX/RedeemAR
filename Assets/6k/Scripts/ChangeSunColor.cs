using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSunColor : MonoBehaviour
{
    public int red = 255;    // Red component (0 to 255)
    public int green = 255;  // Green component (0 to 255)
    public int blue = 255;   // Blue component (0 to 255)
    private Light myLight;   // Reference to the Light component

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    public void SunColor()
    {
        float normalizedRed = red / 255.0f;
        float normalizedGreen = green / 255.0f;
        float normalizedBlue = blue / 255.0f;

        // Set the RGB color of the Light
        myLight.color = new Color(normalizedRed, normalizedGreen, normalizedBlue);
    }
}
