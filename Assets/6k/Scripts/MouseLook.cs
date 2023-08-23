using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.0f; // Adjust the mouse sensitivity
    public float minYAngle = -90.0f; // Minimum vertical angle
    public float maxYAngle = 90.0f;  // Maximum vertical angle

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate camera rotation based on input
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle); // Clamp the vertical rotation

        rotationY += mouseX * sensitivity;

        // Apply rotation to the camera
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
