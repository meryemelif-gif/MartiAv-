using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartButtonManager : MonoBehaviour
{
    public Button startButton;            // Start butonu
    public AudioSource clickSound;        // Týklama sesi
    public ScoreManager scoreManager;     // Skor UI yönetimi
    public LifeManager lifeManager;       // Canlar
    public MartiSpawn martiSpawn;         // Martý spawn script'i

    void Start()
    {
        // Start butonuna týklandýðýnda StartGame() çaðrýlacak
        startButton.onClick.AddListener(StartGame);

        // Oyun baþlamadan önce UI ve spawn gizli olabilir
        if (scoreManager != null) scoreManager.scoreText.gameObject.SetActive(false);
        if (lifeManager != null) lifeManager.DeactivateHearts(); // Kalpleri gizle
        if (martiSpawn != null) martiSpawn.enabled = false;       // Martý spawn kapalý
    }

    void StartGame()
    {
        // Ses çal
        if (clickSound != null) clickSound.Play();

        // Butonu gizle
        startButton.gameObject.SetActive(false);

        // Skor ve kalpleri göster
        if (scoreManager != null) scoreManager.scoreText.gameObject.SetActive(true);
        if (lifeManager != null) lifeManager.ActivateHearts();

        // Martý spawn aktif
        if (martiSpawn != null) martiSpawn.enabled = true;

        Debug.Log("Oyun baþladý!");
    }
}
