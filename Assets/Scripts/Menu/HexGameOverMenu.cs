using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HexGameOverMenu : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverMenu;
    //public GameObject points;
    

    //public TextMeshProUGUI endPoint;
    //public TextMeshProUGUI point;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            //points.SetActive(false);
            gameOverMenu.SetActive(true);
            //endPoint.text = PointUpdate.point.ToString();
            //point.text = "";
        }
        else
        {
            gameOverMenu.SetActive(false);
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

    public void NewPlay()
    {
        SceneManager.LoadScene("GameHex");
        gameOver = false;
        HexYouWinMenu.youWin = false;
        PauseMenu.pause = false;
        Time.timeScale = 1f;

        PointUpdate.point = 0;
        PointUpdate.level = 1;
        HexBrick.mineChance = 0.1;
    }
}
