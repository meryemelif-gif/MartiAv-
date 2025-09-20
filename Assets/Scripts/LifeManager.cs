using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject gameOverPanel;
    public AudioSource gameOverSound;
    public AudioSource uiAudioSource;


    private int lives = 3;
    private bool isGameOver = false;

    void Start()
    {
        // Baþlangýçta panel gizli olsun ve oyun zamaný normal
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoseLife()
    {
        lives--;

        if (lives == 2) heart3.SetActive(false);
        else if (lives == 1) heart2.SetActive(false);
        else if (lives <= 0)
        {
            heart1.SetActive(false);
            GameOver();
        }
    }
    private void GameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (gameOverSound != null) gameOverSound.Play();

        // Oyunu durdur 
        Time.timeScale = 0f;
    }

    // Retry butonunu bu metoda baðlayacaðýz
    public void OnRetryButtonPressed()
    {
        StartCoroutine(ReloadAfterDelay(0.25f));
    }

    IEnumerator ReloadAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Ýsteðe baðlý: oyunu ana menüye döndür
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateHearts()
    {
        if (heart1 != null) heart1.SetActive(true);
        if (heart2 != null) heart2.SetActive(true);
        if (heart3 != null) heart3.SetActive(true);
    }

    public void DeactivateHearts()
    {
        if (heart1 != null) heart1.SetActive(false);
        if (heart2 != null) heart2.SetActive(false);
        if (heart3 != null) heart3.SetActive(false);
    }

}
