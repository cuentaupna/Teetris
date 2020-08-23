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
    
}
