using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonButton : MonoBehaviour
{
    public string lessonName;

    public void LoadQuizScene()
{
    PlayerPrefs.SetString("SelectedLesson", lessonName);
    SceneManager.LoadScene("QuizGame");
}

}
