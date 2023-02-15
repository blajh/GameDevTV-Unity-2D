using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthSlider;

    private void Start() {
        scoreText.text = "000000000";
        healthSlider.value = 1;
    }

    private void Update() {
        timeText.text = "TIME: " + Mathf.Round(Time.timeSinceLevelLoad).ToString("0000");
    }

    public void UpdateScore(int value) {
        scoreText.text = value.ToString("000000000");
    }

    public void UpdateHealth(int maxHP, int currentHP) {
        healthSlider.value = (float)currentHP / maxHP;
    }

    public void UpdateWave(int waveCount) {
        waveText.text = "WAVE: " + waveCount.ToString("0000");
    }

}