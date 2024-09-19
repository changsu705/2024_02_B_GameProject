using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void OnEnable()
    {
        EventSystem.OnScoreChanged += UpdateScore;
        EventSystem.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        EventSystem.OnScoreChanged -= UpdateScore;
        EventSystem.OnGameOver -= ShowGameOver;
    }

    void UpdateScore(int newScore)
    {
        Debug.Log($"Score updat: {newScore}");
    }

    void ShowGameOver()
    {
        Debug.Log("Game Over!");
    }
}
