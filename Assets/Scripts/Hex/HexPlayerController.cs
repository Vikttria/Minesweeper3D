﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class HexPlayerController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public TextMeshProUGUI pointText;

    public TextMeshProUGUI levelText;

    public int timer;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        //bal egér klikk
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                HexBrick hexBrick = hitObject.GetComponent<HexBrick>();
                if (hexBrick != null)
                {
                    //ide helyezi át a playert
                    navMeshAgent.SetDestination(hit.transform.position);

                    if (!hexBrick.isMine)
                    {
                        PointUpdate.point += 2;
                    }
                    if (hexBrick.youWin)
                    {
                        Destroy(gameObject);
                        HexYouWinMenu.youWin = true;
                        Time.timeScale = 0;
                    }
                }
            }
            
        }
        //jobb egér klikk
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                HexBrick hexBrick = hitObject.GetComponent<HexBrick>();
                if (hexBrick != null)
                {
                    if (!hexBrick.isMine)
                    {
                        Destroy(gameObject);
                        HexGameOverMenu.gameOver = true;
                        Time.timeScale = 0;
                        
                    }
                    else
                    {
                        if (hexBrick.isShowed) return;
                        hexBrick.isShowed = true;
                        hexBrick.isMine = false;

                        string name = "HexTileFlag";

                        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/MinesweeperSpritesheet");

                        Sprite sprite;
                        if (HexBrick.mineTileImages.TryGetValue(name, out sprite))
                        {
                            hexBrick.tile.sprite = sprite;
                        }

                        PointUpdate.point += 4;
                    }
                }
            }
        }

        DetectMine();

        pointText.text = PointUpdate.point.ToString();
        levelText.text = PointUpdate.level.ToString() + " level";
    }

    private void FixedUpdate()
    {
        
    }

    private void DetectMine()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.2f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            HexBrick hexBrick = hitObject.GetComponent<HexBrick>();
            if (hexBrick != null)
            {
                hexBrick.ShowSecret();

                if (hexBrick.isMine)
                {
                    Destroy(gameObject);
                    HexGameOverMenu.gameOver = true;
                    Time.timeScale = 0;
                }
            }

        }
    }

    void Timer()
    {
        if (timer < Time.timeSinceLevelLoad)
        {
            PointUpdate.point--;
            timer++;
        }
    }
}
