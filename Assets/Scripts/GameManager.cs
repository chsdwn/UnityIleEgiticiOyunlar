using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Question[] questions { get; private set; }

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

        SetQuestionIndex();
    }

    void SetQuestionIndex()
    {
        questionIndex = Random.Range(0, unansweredQuestions.Count);
    }
}
