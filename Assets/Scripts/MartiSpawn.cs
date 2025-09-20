using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartiSpawn : MonoBehaviour
{
    public GameObject martiSagPrefab;
    public GameObject martiSolPrefab;

    // Alt�n mart� prefab
    public GameObject bonusMartiPrefab;

    public float minY = 2f;
    public float maxY = 5f;
    public float spawnSure = 3f;

    // Alt�n mart� ��kma �ans�
    public float bonusMartiChance = 0.1f; // %10

    void Start()
    {
        InvokeRepeating("SpawnMarti", 1f, spawnSure);
    }

    void SpawnMarti()
    {
        // Sahnede max 5 mart�
        if (GameObject.FindGameObjectsWithTag("Marti").Length >= 5)
            return;

        float y = Random.Range(minY, maxY);
        GameObject martiToSpawn;
        float xPos;

        // Alt�n mart� m� ��kacak?
        if (Random.value < bonusMartiChance)
        {
            martiToSpawn = bonusMartiPrefab;
            xPos = -8f; // Soldan ��kacak
        }
        else
        {
            // Normal mart�lar
            if (Random.value < 0.5f)
            {
                martiToSpawn = martiSolPrefab;
                xPos = -8f;
            }
            else
            {
                martiToSpawn = martiSagPrefab;
                xPos = 8f;
            }
        }

        Instantiate(martiToSpawn, new Vector3(xPos, y, 0), Quaternion.identity);
    }
}
