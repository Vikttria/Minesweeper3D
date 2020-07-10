using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class YouWinMenu : MonoBehaviour
{
    public static bool youWin = false;
    public GameObject youWinMenu;
    //public GameObject points;

    //public TextMeshProUGUI endPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (youWin)
        {
            youWinMenu.SetActive(true);
            //points.SetActive(false);
            //endPoint.text = PointUpdate.point.ToString();
        }
        else
        {
            youWinMenu.SetActive(false);
            //points.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void NexLevel()
    {
        SceneManager.LoadScene("Game");

        GameOverMenu.gameOver = false;
        YouWinMenu.youWin = false;
        Time.timeScale = 1f;

        Brick.mineChance += 0.2;
        PointUpdate.level++;
    }
}
