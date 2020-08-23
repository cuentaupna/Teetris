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
        //Debug.Log(y+" "+x);
        if (x < 0 || x > 9 || y > 15)
            return true;
        return tiles[y, x].IsTheTileEmpty();
    }
    public void ChangeStateOfTiles(int x, int y, Tile.TileStateEnum newState, Square newSquare)
    {
        
        tiles[y, x].ChangeState(newState, newSquare);
        if(newState == Tile.TileStateEnum.full)
        {
            int counter = 0;
            List<int> squaresToPull = new List<int>();
            List<int> squaresToDelete = new List<int>();
            for (int i = 0; i < 16; ++i)
            {
                counter = 0;
                for (int j = 0; j < 10; ++j)
                {
                    if (!tiles[i, j].IsTheTileEmpty())
                    {
                        ++counter;
                    }
                    else
                    {
                        if (i != 0)
                            squaresToPull.Add(i);
                        break;
                    }
                }
                if(counter == 10)
                {
                    squaresToDelete.Add(i);
                }
            }
            if(squaresToDelete.Count != 0)
            {
                foreach (int row in squaresToDelete)
                {
                    for (int column = 0; column < 10; ++column)
                    {
                        //tiles[row, column].
                    }
                }
            }
        }
    }
}
