using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Question[] questions { get; private set; }

    [SerializeField]
    private Text questionText, correctAnswerText, wrongAnswerText;

    List<Question> unansweredQuestions;
    int questionIndex;

    private void Awake()
    {
        questions = new Question[] {
            new Question { question = "Şarkılar her zaman beyitlerden oluşur.", isCorrect = false },
            new Question { question = "Şarkı türünün en önemli ismi Nedim'dir.", isCorrect = true },
            new Question { question = "Tuyuğ bir Türk nazım şeklidir.", isCorrect = true }
        };
    }

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList();
        }

        PrintQuestion();
    }

    public void CheckAnswerIsCorrect(bool answer)
    {
        if (answer == unansweredQuestions[questionIndex].isCorrect)
        {

        }

        StartCoroutine(WaitBetweenQuestionsRoutine());
    }

    void SetQuestionIndex()
    {
        questionIndex = Random.Range(0, unansweredQuestions.Count);
    }

    void PrintQuestion()
    {
        SetQuestionIndex();
        PrintResult();

        questionText.text = unansweredQuestions[questionIndex].question;
    }

    void RemoveAnsweredQuestion()
    {
        unansweredQuestions.RemoveAt(questionIndex);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PrintResult()
    {
        if (unansweredQuestions[questionIndex].isCorrect)
        {
            correctAnswerText.text = "DOĞRU CEVAP";
            wrongAnswerText.text = "YANLIŞ CEVAP";
        }
        else
        {
            correctAnswerText.text = "YANLIŞ CEVAP";
            wrongAnswerText.text = "DOĞRU CEVAP";
        }
    }

    IEnumerator WaitBetweenQuestionsRoutine()
    {
        yield return new WaitForSeconds(1f);

        RemoveAnsweredQuestion();
        LoadScene();
    }
}
