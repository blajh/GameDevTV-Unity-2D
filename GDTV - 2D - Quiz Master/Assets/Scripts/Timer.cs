using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField] private float timeToCompleteQuestion = 30f;
    [SerializeField] private float timeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;
    
    private float timerValue;

    private void Update() {
        UpdateTimer();
    }

    private void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if (timerValue <= 0 && !isAnsweringQuestion) {
            isAnsweringQuestion = true;
            timerValue = timeToShowCorrectAnswer;
        } else if (timerValue <= 0 && isAnsweringQuestion) {
            isAnsweringQuestion = false;
            timerValue = timeToCompleteQuestion;
        }

        Debug.Log(timerValue);
    }
}
