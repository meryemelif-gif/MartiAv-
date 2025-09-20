using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartiHareket : MonoBehaviour
{
    public float hizX = 2f; // Başlangıç hızı
    private int direction = 1;

    [SerializeField] private ScoreManager scoreManager; // Inspector’dan bağlayacağız

    void Start()
    {
        if (scoreManager == null)
            scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        
        // Martının yönü
        if (transform.position.x < 0)
            direction = 1;
        else
            direction = -1;
    }

    void Update()
    {
        if (scoreManager != null)
        {
            // Martının hızı skora bağlı olarak artıyor (kolay → zor)
            hizX = 2f + scoreManager.GetCurrentScore() * 1f;
        }

        // Eğer Bonus martı ise ekstra hız ekle
        if (gameObject.CompareTag("Bonus"))
        {
            hizX += 1.5f; // Bonus martılara ekstra hız
        }

        // Martıyı hareket ettir
        transform.position += new Vector3(direction * hizX * Time.deltaTime, 0, 0);

        // Eğer martı yere değerse can kaybet
        if (transform.position.y < -4.5f)
        {
            LifeManager lifeManager = GameObject.Find("GameManager").GetComponent<LifeManager>();
            lifeManager.LoseLife();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D diger)
    {
        if (diger.CompareTag("Simit"))
        {
            Destroy(diger.gameObject);
            Destroy(gameObject);

            // Puan belirleme
            int pointsToAdd = (gameObject.CompareTag("Bonus")) ? 3 : 1;

            // Puan ekleme
            if (scoreManager != null)
                scoreManager.AddScore(pointsToAdd);
            else
                Debug.LogError("ScoreManager referansı yok!");

            // High Score kontrolü
            HighScoreManager hsm = GameObject.Find("GameManager").GetComponent<HighScoreManager>();
            hsm.CheckHighScore(scoreManager.GetCurrentScore());

            Debug.Log("CheckHighScore çağrıldı: " + scoreManager.GetCurrentScore());
        }
    }
}
