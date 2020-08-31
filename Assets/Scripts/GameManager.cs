using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Question[] questions { get; private set; }

    void Start()
    {
        questions = new Question[] {
            new Question { question = "Şarkılar her zaman beyitlerden oluşur.", isCorrect = false },
            new Question { question = "Şarkı türünün en önemli ismi Nedim'dir.", isCorrect = true },
            new Question { question = "Tuyuğ bir Türk nazım şeklidir.", isCorrect = true }
        };
    }
}
