using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstacle;
    private float timeToSpawn = 3f;
    private float spawnCooldown = 3f;

    void SpawnLines()
    {
        int maxIndex = spawnPoints.Length;
        Vector3 offset = new Vector3(0.0f, 0.0f, 40.0f);

        for (int i = 0; i < 4; i++)
        {
            int randomIndex1 = Random.Range(0, maxIndex);
            int randomIndex2 = Random.Range(0, maxIndex);
            for (int j = 0; j < spawnPoints.Length; j++)
            {
                if ((j != randomIndex1))
                {
                    if ((j != randomIndex2))
                    {
                        Instantiate(obstacle, spawnPoints[j].position + i * offset, Quaternion.identity);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnLines();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<GameManager>().isGameOver())
        {
            if (Time.timeSinceLevelLoad >= timeToSpawn)
            {
                SpawnLines();
                timeToSpawn = Time.timeSinceLevelLoad + spawnCooldown;
            }
        }
    }
}
