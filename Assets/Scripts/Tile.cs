using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
    public enum TileStateEnum { empty, full}
    public TileStateEnum tileState;
    private GameObject leGameObject;
    public Square leSquare;
    // Start is called before the first frame update
    void Start()
    {
        tileState = TileStateEnum.empty;
    }
    public bool IsTheTileEmpty()
    {
        return tileState == TileStateEnum.empty;
    }

    public void ChangeState(TileStateEnum newState, Square newSquare)
    {
        tileState = newState;
        if (newState == TileStateEnum.full)
            leSquare = newSquare;
        else
        {
            leSquare = null;
        }
        if(leSquare != null)
        {
            Debug.Log("It works");
        }
    }
    
    public void MakeSquareFall()
    {
        if(leSquare != null)
        {
            //leSquare.MakeEmFall();
            Vector2 pos = leSquare.transform.localPosition;
            pos.y--;
            leSquare.MoveSquare(pos.x, pos.y);
            leSquare = null;
            tileState = TileStateEnum.empty;
        }
    }

    public void LetSquareGo()
    {
        if(leSquare != null)
        {
            leSquare.MakeSquareSleep();
            tileState = TileStateEnum.empty;
        }
    }
}
