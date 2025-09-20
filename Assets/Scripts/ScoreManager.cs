using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public GameObject plusTextPrefab; // +1 veya +3 g�sterecek prefab
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource; // Puan sesi i�in

    private int score = 0;

    public int GetCurrentScore()
    {
        return score;  // private score�u d��ar�ya g�venli �ekilde a��yoruz
    }

    void Start()
    {
        UpdateScoreText();
    }

    // Mart�y� vurdu�unda AddScore �a�r�l�r
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        ShowPlusText(points);

        if (audioSource != null)
            audioSource.Play();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void ShowPlusText(int points)
    {
        // +Text objesini kopyala ve aktif et
        GameObject t = Instantiate(plusTextPrefab, plusTextPrefab.transform.position, Quaternion.identity, plusTextPrefab.transform.parent);
        t.SetActive(true);

        // E�er TextMeshPro varsa puan� g�ster
        TextMeshProUGUI tmp = t.GetComponent<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = "+" + points.ToString();
        }

        // 0.5 saniye sonra kaybol
        Destroy(t, 0.5f);
    }
}
