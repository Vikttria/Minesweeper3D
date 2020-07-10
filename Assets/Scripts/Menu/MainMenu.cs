using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        GameOverMenu.gameOver = false;
        YouWinMenu.youWin = false;
        PauseMenu.pause = false;
        Time.timeScale = 1f;
        PointUpdate.point = 0;
        PointUpdate.level = 1;
        Brick.mineChance = 0.1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HexPlayGame()
    {
        SceneManager.LoadScene("GameHex");
        HexGameOverMenu.gameOver = false;
        HexYouWinMenu.youWin = false;
        PauseMenu.pause = false;
        Time.timeScale = 1f;
        PointUpdate.point = 0;
        PointUpdate.level = 1;
        HexBrick.mineChance = 0.1;
    }

}
