using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizResultPopup : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    private void Start()
    {
        // Hide the pop-up panel initially
        gameObject.SetActive(false);
    }

    public void ShowResult(int totalCorrect, bool isLastQuestion)
    {
        resultText.text = "Total Correct Answers: " + totalCorrect.ToString();

        // Show the pop-up panel only if it's the last question
        if (isLastQuestion)
        {
            gameObject.SetActive(true);
        }
    }

    // Call this function from your "Return to Quiz Mode" button's onClick event
    public void ReturnToQuizModeButtonClick()
    {
        SceneManager.LoadScene("QuizMode"); // Load the specific scene named "QuizMode"
    }
}
