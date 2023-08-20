using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBtn : MonoBehaviour
{
    
    void Update()
    {
        
    }
    public void StoryMode()
    {
        SceneManager.LoadScene("Storymode");
    }
    public void QuizMode()
    {
        SceneManager.LoadScene("Quizmode");
    }
    public void QuizBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}