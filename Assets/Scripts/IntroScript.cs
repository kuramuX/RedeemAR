using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float wait_time = 7f;  // This can be kept if you want a fixed duration

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;  // Subscribe to the loopPointReached event
        videoPlayer.Play();  // Play the video
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
