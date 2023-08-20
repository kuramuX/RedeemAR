using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    public void TogglePanelVisibility()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
