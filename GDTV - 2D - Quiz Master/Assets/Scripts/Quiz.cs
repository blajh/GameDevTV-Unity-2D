using System;
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
        SetupCorrectIndex();
        GetNextQuestion();
        //DisplayQuestion();
    }

    private void SetupCorrectIndex() {
        correctAnswerIndex = questionSO.GetCorrectAnswerIndex();
    }

    private void DisplayQuestion() {
        DisplayQuestionText();
        DisplayAnswersText();
        SetButtonsState(true);
    }

    private void DisplayQuestionText() {
        questionText.text = questionSO.GetQuestion();
    }

    private void DisplayAnswersText() {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionSO.GetAnswer(i);
        }
    }

    private void SetButtonsState(bool state) {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].interactable = state;
        }
    }

    public void OnAnswerSelected(int index) {
        if (index == correctAnswerIndex) {
            CorrectAnswer();

        } else {
            IncorrectAnswer();
        }
        SetButtonsState(false);
        GetNextQuestion();
    }

    private void CorrectAnswer() {
        questionText.text = "Correct";
        answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;
    }

    private void IncorrectAnswer() {
        questionText.text = "The correct answer was:\n" + questionSO.GetAnswer(correctAnswerIndex);
        answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;
    }

    private void GetNextQuestion() {
        SetButtonsState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    private void SetDefaultButtonSprites() {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
}
