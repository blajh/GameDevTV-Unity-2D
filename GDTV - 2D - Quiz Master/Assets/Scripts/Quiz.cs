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
    [SerializeField] private TextMeshProUGUI[] answersTexts = new TextMeshProUGUI[MAX_ANSWERS_PER_QUESTION];

    private void Start() {
        //SetupQuestion(); // Using text fields
        SetupQuestionAlt(); // Using text fields as button children
    }

    private void SetupQuestion() {
        SetQuestionText();
        for (int i = 0; i < answersTexts.Length; i++) {
            answersTexts[i].text = questionSO.GetAnswer(i);
        }
    }

    private void SetupQuestionAlt() {
        SetQuestionText();
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionSO.GetAnswer(i);
        }
    }

    private void SetQuestionText() {
        questionText.text = questionSO.GetQuestion();
    }
}
