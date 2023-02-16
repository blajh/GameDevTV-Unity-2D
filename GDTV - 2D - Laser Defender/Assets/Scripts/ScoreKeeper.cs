using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    private static ScoreKeeper Instance;

    private UIDisplay uiDisplay;

    private int score = 0;
    private int time = 0;
    private int wave = 0;

    private void Awake() {
        uiDisplay = FindObjectOfType<UIDisplay>();
        ManageInstance();
    }

    private void ManageInstance() {
        if (Instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return score;
    }

    public void ModifyScore(int amount) {
        score += amount;
        Mathf.Clamp(score, 0, int.MaxValue);
        uiDisplay.UpdateScore(score);
    }

    public void ResetScore() {
        score = 0;
    }

    public void ResetWaves() {
        wave = 0;
    }

    public int GetWave() {
        return wave;
    }

    public void ModifyWave(int amount) {
        wave += amount;
        Mathf.Clamp(wave, 0, int.MaxValue);
    }

    public int GetTimePlayed() {
        return time;
    }

    public void SetTimePlayed(float timePlayed) {
        time = (int)timePlayed;
    }
}