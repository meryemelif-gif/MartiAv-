using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimitHareket : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�arp��ma oldu: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Marti"))
        {
            // Score art���
            GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore(1);

            // Mart�y� yok et
            Destroy(collision.gameObject);

            // Simiiti yok et
            Destroy(gameObject);
        }
    }
}
