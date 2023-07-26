using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public GameObject gameOverUI;
    public Text ScoreSrc;
    public Text FinalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverUI.SetActive(true);
            FinalScoreText.text = $"Final Score : " +  ScoreSrc.text;
        }
    }

    public bool isGameOver()
    {
        return gameOver;
    }


}
