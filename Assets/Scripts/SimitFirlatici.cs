using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimitFirlatici : MonoBehaviour
{
    public GameObject simitPrefab;  // Simit prefab
    public float hizYukari = 5f;    // Yukarý fýrlatma hýzý

    void Update()
    {
        // Fareyi takip et
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        // Sol týk ile simit fýrlat
        if (Input.GetMouseButtonDown(0))
        {
            GameObject simit = Instantiate(simitPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = simit.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, hizYukari); // Yukarý doðru
        }
    }
}
