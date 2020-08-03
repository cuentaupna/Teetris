using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject[,] tilesGameObj = new GameObject[16,10];
    public GameObject Tetri;
    private Tetromino TS;
    private Tile[,] tiles = new Tile[16,10];
    // Start is called before the first frame update
    void Start()
    {
        Vector2 tilePosition = new Vector2(0, 0);
        TS = Tetri.GetComponent<Tetromino>();
        for(int i = 0; i < 16; ++i)
        {
           for(int j = 0; j < 10; ++j)
            {
                tilesGameObj[i, j] = Instantiate(tile, tilePosition, Quaternion.identity);
                tiles[i, j] = tilesGameObj[i, j].GetComponent<Tile>();
                ++tilePosition.x;
                
            }
            tilePosition.x = 0;
            ++tilePosition.y;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveTetri(int x, int y)
    {
        TS.MoveParent(x, y);
    }
    public void RotateTetri(int p)
    {
        TS.Rotate(p);
    }
    public bool CheckTile(int x, int y)
    {
        //Check this again
        if (x < 0 || x > 9 || y > 15)
            return true;
        return tiles[y, x].IsTheTileEmpty();
    }
}
