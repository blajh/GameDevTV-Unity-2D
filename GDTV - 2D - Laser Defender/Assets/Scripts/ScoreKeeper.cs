using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private UIDisplay uiDisplay;

    private int score = 0;

    private void Awake() {
        uiDisplay = FindObjectOfType<UIDisplay>();
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
}