using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using System.IO; 

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public List<Button> optionButtons;
    public QuizResultPopup resultPopup;

    private List<Question> questions;
    private int currentQuestionIndex = 0;
    private int totalCorrectAnswers = 0;

    void Start()
    {
        questionText = GameObject.Find("questionText").GetComponent<TextMeshProUGUI>();
        StartCoroutine(LoadQuestionsCoroutine());
    }

    IEnumerator LoadQuestionsCoroutine()
    {
        string selectedLesson = PlayerPrefs.GetString("SelectedLesson");
        string jsonPath = Path.Combine(Application.streamingAssetsPath, "QuizData/quiz_data.json");

        using (UnityWebRequest www = UnityWebRequest.Get(jsonPath))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error loading JSON: " + www.error);
            }
            else
            {
                string jsonData = www.downloadHandler.text;
                QuizData quizData = JsonUtility.FromJson<QuizData>(jsonData);

                foreach (var lesson in quizData.lessons)
                {
                    if (lesson.lessonName == selectedLesson)
                    {
                        questions = lesson.questions;
                        break;
                    }
                }

                LoadQuestion(currentQuestionIndex);
            }
        }
    }

    void LoadQuestion(int index)
    {
        if (index < questions.Count)
        {
            questionText.text = questions[index].questionText;

            for (int i = 0; i < optionButtons.Count; i++)
            {
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[index].options[i];
                string selectedOption = questions[index].options[i];
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(selectedOption));
            }
        }
        else
        {
            resultPopup.ShowResult(totalCorrectAnswers, true);
        }
    }

    void OnOptionSelected(string selectedOption)
    {
        string correctOption = questions[currentQuestionIndex].options[questions[currentQuestionIndex].correctOptionIndex];

        for (int i = 0; i < optionButtons.Count; i++)
        {
            string buttonText = optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text;

            if (buttonText == selectedOption)
            {
                if (selectedOption == correctOption)
                {
                    totalCorrectAnswers++;
                    optionButtons[i].image.color = Color.yellow;
                }
                else
                {
                    optionButtons[i].image.color = Color.red;
                    for (int j = 0; j < optionButtons.Count; j++)
                    {
                        string correctButtonText = optionButtons[j].GetComponentInChildren<TextMeshProUGUI>().text;
                        if (correctButtonText == correctOption)
                        {
                            optionButtons[j].image.color = Color.yellow;
                            break;
                        }
                    }
                }
            }
            optionButtons[i].interactable = false;
        }

        if (currentQuestionIndex == questions.Count - 1)
        {
            resultPopup.ShowResult(totalCorrectAnswers, true);
        }
        else
        {
            Invoke("LoadNextQuestion", 2f);
        }
    }

    void LoadNextQuestion()
    {
        foreach (Button button in optionButtons)
        {
            button.image.color = Color.white;
            button.interactable = true;
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            LoadQuestion(currentQuestionIndex);
        }
        else
        {
            resultPopup.ShowResult(totalCorrectAnswers, true);
        }
    }
}

[System.Serializable]
public class QuizData
{
    public List<Lesson> lessons;
}

[System.Serializable]
public class Lesson
{
    public string lessonName;
    public List<Question> questions;
}

[System.Serializable]
public class Question
{
    public string questionText;
    public List<string> options;
    public int correctOptionIndex;
}
