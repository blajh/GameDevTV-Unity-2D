using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField] private float timeToCompleteQuestion = 30f;
    [SerializeField] private float timeToShowCorrectAnswer = 10f;

    [SerializeField] private Image filledImage;

    public bool loadNextQuestion;
    public bool isAnsweringQuestions = false;
    
    private float timerValue;

    private void Update() {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    private void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestions) {
            if (timerValue > 0) {
                ImageFill();
            } else if (timerValue <= 0) {
                isAnsweringQuestions = false;
                timerValue = timeToShowCorrectAnswer;
            }
        } else if (!isAnsweringQuestions) {
            if (timerValue > 0) {
                ImageFill();
            } else if (timerValue <= 0) {
                isAnsweringQuestions = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }        
    }

    private void ImageFill() {
        if (isAnsweringQuestions) {
            filledImage.fillAmount = timerValue / timeToCompleteQuestion;
        } else if (!isAnsweringQuestions) {
            filledImage.fillAmount = 1 - (timerValue / timeToShowCorrectAnswer);
        }
        
    }
}
