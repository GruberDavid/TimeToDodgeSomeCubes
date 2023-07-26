using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrQuit : MonoBehaviour
{
    public Score score;
    public BonusMenu bonusMenu;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BonusMenu()
    {
        bonusMenu.gameObject.SetActive(true);
        bonusMenu.UpdateUI();
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
