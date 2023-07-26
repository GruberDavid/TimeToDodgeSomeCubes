using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public int score;
    public Text scoreText;
    private int multiplicator = 1;

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
            score = Mathf.FloorToInt(Time.timeSinceLevelLoad) * 100 * multiplicator;
            scoreText.text = score.ToString();
        }
    }

    public void setMultiplicator(int new_multiplicator) {
        this.multiplicator = new_multiplicator;
    }

    public int getMultiplicator(){
        return this.multiplicator;
    }

}
