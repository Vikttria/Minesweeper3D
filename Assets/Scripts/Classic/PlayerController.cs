using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
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
                Brick brick = hitObject.GetComponent<Brick>();
                if (brick != null)
                {
                    //ide helyezi át a playert
                    navMeshAgent.SetDestination(hit.transform.position);

                    if (!brick.isMine)
                    {
                        PointUpdate.point += 2;
                    }
                    if (brick.youWin)
                    {
                        Destroy(gameObject);
                        YouWinMenu.youWin = true;
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
                Brick brick = hitObject.GetComponent<Brick>();
                if (brick != null)
                {
                    if (!brick.isMine)
                    {
                        Destroy(gameObject);
                        GameOverMenu.gameOver = true;
                        Time.timeScale = 0;
                        
                    }
                    else
                    {
                        if (brick.isShowed) return;
                        brick.isShowed = true;
                        brick.isMine = false;

                        string name = "TileFlag";

                        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/MinesweeperSpritesheet");

                        Sprite sprite;
                        if (Brick.mineTileImages.TryGetValue(name, out sprite))
                        {
                            brick.tile.sprite = sprite;
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
            Brick brick = hitObject.GetComponent<Brick>();
            if (brick != null)
            {
                brick.ShowSecret();

                if (brick.isMine)
                {
                    Destroy(gameObject);
                    GameOverMenu.gameOver = true;
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
