using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Önceki en yüksek skoru yükle
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
    }

    public void CheckHighScore(int currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreUI();
        }
    }

    void UpdateHighScoreUI()
    {
        if (highScoreText != null)
            highScoreText.text = "Rekor: " + highScore;
    }
}
