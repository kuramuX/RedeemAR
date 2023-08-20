using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName; // Name of the scene to load (make sure the scene is added to the build settings)

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Load the specified scene
    }
}
