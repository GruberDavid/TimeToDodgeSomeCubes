using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<GameManager>().isGameOver())
        {
            score = Mathf.FloorToInt(Time.timeSinceLevelLoad) * 100;
            scoreText.text = score.ToString();
        }
    }
}
