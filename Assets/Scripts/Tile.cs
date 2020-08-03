using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
    public enum TileStateEnum { empty, full}
    public TileStateEnum tileState;
    // Start is called before the first frame update
    void Start()
    {
        tileState = TileStateEnum.empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsTheTileEmpty()
    {
        return tileState == TileStateEnum.empty;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Landed"))
            tileState = TileStateEnum.full;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        tileState = TileStateEnum.empty;
    }
}
