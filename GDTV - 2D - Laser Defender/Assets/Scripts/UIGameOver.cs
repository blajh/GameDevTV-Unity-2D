using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI timeText;

    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() {
        scoreText.text = "score:\n" + scoreKeeper.GetScore().ToString("000000000");
        waveText.text = "wave: " + scoreKeeper.GetWave().ToString("0000");
        timeText.text = "time: " + scoreKeeper.GetTimePlayed().ToString("0000");
    }
}
