using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(VideoPlayer))]
public class PlayVideoAndChangeScene : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    private ARTrackedImageManager imageManager;
    private VideoPlayer videoPlayer;

    private void Start()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.isLooping = false; // Set to false so the video plays once
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Prepare();

        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            if (trackedImage.referenceImage.name == "YourImageName")
            {
                videoPlayer.Play();
                break;
            }
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video finishes
        SceneManager.LoadScene(nextSceneName);
    }
}
