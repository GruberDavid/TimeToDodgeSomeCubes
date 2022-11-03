using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstacle;
    public float timeToSpawn = 5f;
    public float spawnCooldown = 5f;

    public Score score;
    public int trous = 6;
    public List<int> randomList;

    public ObstacleMovement obstacleMovement;

    void SpawnLines(int nbLines)
    {

        int maxIndex = spawnPoints.Length;
        Vector3 offset = new Vector3(0.0f, 0.0f, 40.0f);

        for (int i = 0; i < nbLines; i++)
        {
            this.randomList = new List<int>();
            for(int j = 0; j < this.trous; j++){
                int randomIndex = Random.Range(0, maxIndex);
                this.randomList.Add(randomIndex);
            }
            
            for (int j = 0; j < spawnPoints.Length; j++)
            {
                if (!this.randomList.Contains(j))
                {
                    Instantiate(obstacle, spawnPoints[j].position + (4-i) * offset, Quaternion.identity);
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
                Debug.Log("VITESSE : " + obstacleMovement.speed);
                if(this.score.score > 5000) {
                    this.trous = 5;
                    obstacleMovement.speed = 21.5f;
                }
                if(this.score.score > 10000) {
                    this.trous = 4;
                    obstacleMovement.speed = 22.5f;
                }
                if(this.score.score > 15000) {
                    this.trous = 3;
                    obstacleMovement.speed = 25f;
                }
                if(this.score.score > 20000) {
                    this.trous = 2;
                    obstacleMovement.speed = 27.5f;
                }
                if(this.score.score > 25000) {
                    this.trous = 1;
                    obstacleMovement.speed = 30f;
                }
                SpawnLines(2);
                timeToSpawn = Time.timeSinceLevelLoad + spawnCooldown;
            }
        }
    }
}
