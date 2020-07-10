using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexBrick : MonoBehaviour
{
    //van-e akna
    public bool isMine = false;
    public float radius = 1.42f;

    public List<HexBrick> mineNeighbors;

    public static Dictionary<string, Sprite> mineTileImages;

    public bool isShowed = false;
    public SpriteRenderer tile = null;

    public bool youWin = false;

    public static double mineChance;

    // Start is called before the first frame update
    void Start()
    {
        isMine = Random.value < mineChance;

        BuildSpritesMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnValidate()
    {
        FindNeighbors();
    }

    void FindNeighbors()
    {
        var allBricks = GameObject.FindGameObjectsWithTag("HexBrick");

        mineNeighbors = new List<HexBrick>();

        for (int i = 0; i < allBricks.Length; i++)
        {
            var brick = allBricks[i];
            var distance = Vector3.Distance(transform.position, brick.transform.position);
            if (0 < distance && distance <= radius)
            {
                mineNeighbors.Add(brick.GetComponent<HexBrick>());
            }
        }
        
    }

    public static void BuildSpritesMap()
    {
        if (mineTileImages == null)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/MinesweeperSpritesheet");
            mineTileImages = new Dictionary<string, Sprite>();
            for (int i = 0; i < sprites.Length; i++)
            {
                mineTileImages.Add(sprites[i].name, (Sprite)sprites[i]);
            }
        }
    }

    public void ShowSecret()
    {
        if (isShowed) return;

        isShowed = true;

        string name;

        if (isMine)
        {
            name = "HexTileMine";
        }
        else
        {
            int num = 0;
            mineNeighbors.ForEach(x => { if (x.isMine) num++; });
            name = $"HexTile{num}";
        }

        Sprite sprite;
        if (mineTileImages.TryGetValue(name, out sprite))
        {
            tile.sprite = sprite;
        }
    }

}
