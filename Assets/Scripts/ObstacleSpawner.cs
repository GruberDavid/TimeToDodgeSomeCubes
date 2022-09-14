using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstacle;
    public float timeToSpawn = 5f;
    public float spawnCooldown = 5f;

    void SpawnLines(int nbLines)
    {
        int maxIndex = spawnPoints.Length;
        Vector3 offset = new Vector3(0.0f, 0.0f, 40.0f);

        for (int i = 0; i < nbLines; i++)
        {
            int randomIndex1 = Random.Range(0, maxIndex);
            int randomIndex2 = Random.Range(0, maxIndex);
            for (int j = 0; j < spawnPoints.Length; j++)
            {
                if ((j != randomIndex1))
                {
                    if ((j != randomIndex2))
                    {
                        Instantiate(obstacle, spawnPoints[j].position + (4-i) * offset, Quaternion.identity);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnLines(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<GameManager>().isGameOver())
        {
            if (Time.timeSinceLevelLoad >= timeToSpawn)
            {
                SpawnLines(2);
                timeToSpawn = Time.timeSinceLevelLoad + spawnCooldown;
            }
        }
    }
}
