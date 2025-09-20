using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartButtonManager : MonoBehaviour
{
    public Button startButton;            // Start butonu
    public AudioSource clickSound;        // T�klama sesi
    public ScoreManager scoreManager;     // Skor UI y�netimi
    public LifeManager lifeManager;       // Canlar
    public MartiSpawn martiSpawn;         // Mart� spawn script'i

    void Start()
    {
        // Start butonuna t�kland���nda StartGame() �a�r�lacak
        startButton.onClick.AddListener(StartGame);

        // Oyun ba�lamadan �nce UI ve spawn gizli olabilir
        if (scoreManager != null) scoreManager.scoreText.gameObject.SetActive(false);
        if (lifeManager != null) lifeManager.DeactivateHearts(); // Kalpleri gizle
        if (martiSpawn != null) martiSpawn.enabled = false;       // Mart� spawn kapal�
    }

    void StartGame()
    {
        // Ses �al
        if (clickSound != null) clickSound.Play();

        // Butonu gizle
        startButton.gameObject.SetActive(false);

        // Skor ve kalpleri g�ster
        if (scoreManager != null) scoreManager.scoreText.gameObject.SetActive(true);
        if (lifeManager != null) lifeManager.ActivateHearts();

        // Mart� spawn aktif
        if (martiSpawn != null) martiSpawn.enabled = true;

        Debug.Log("Oyun ba�lad�!");
    }
}
