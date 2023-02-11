using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName ="QuestionSO")]
public class QuestionSO : ScriptableObject
{
    private const int MAX_ANSWERS_PER_QUESTION = 4;

    [TextArea(2, 6)]
    [SerializeField] private string question = "Enter new question here";
    [SerializeField] private string[] answers = new string[MAX_ANSWERS_PER_QUESTION];
    [SerializeField] private int correctAnswerIndex;

    public string GetQuestion() {
        return question;
    }

    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index) { 
        return answers[index];
    }
}
