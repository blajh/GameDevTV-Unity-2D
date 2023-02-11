using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    private const int MAX_ANSWERS_PER_QUESTION = 4;

    [SerializeField] private QuestionSO questionSO;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] answerButtons = new Button[MAX_ANSWERS_PER_QUESTION];
    
    int correctAnswerIndex;
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    private void Start() {
        correctAnswerIndex = questionSO.GetCorrectAnswerIndex();
        SetupQuestion();
    }

    private void Update() {
        
    }

    public void OnAnswerSelected(int index) {
        if (index == correctAnswerIndex) {
            questionText.text = "Correct";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;

        } else {
            questionText.text = "The correct answer was:\n" + questionSO.GetAnswer(correctAnswerIndex);
            answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;
        }
    }

    private void SetupQuestion() {
        SetQuestionText();
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionSO.GetAnswer(i);
        }
    }

    private void SetQuestionText() {
        questionText.text = questionSO.GetQuestion();
    }
}
