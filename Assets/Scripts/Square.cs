using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private Tetromino sqParent;
    private Coroutine rutine;
    // Start is called before the first frame update
    void Start()
    {
        ResetSquare();
    }
    
    public void ResetSquare()
    {
        gameObject.SetActive(true);
        rutine = StartCoroutine(CheckBorders());
    }
    private IEnumerator CheckBorders()
    {
        //Debug.Log("Starting coroutine");
        for (; ; )
        {
            if (transform.position.x < 0)
            {
                sqParent.MoveParent(1, 0);
            }
            else if (transform.position.x > 10)
            {
                sqParent.MoveParent(-1, 0);
            }
            //Debug.Log("Coroutine loop" + Time.deltaTime);
            yield return null;
        }
    }
    public void MoveSquare(float x, float y)
    {
        
        transform.localPosition = new Vector2(x, y);
    }
    public void AssignParent(Tetromino tetraParent)
    {
        sqParent = tetraParent;
    }
    public void LandSquare()
    {
        StopCoroutine(rutine);
        gameObject.layer = LayerMask.NameToLayer("Landed");
        sqParent.gameManager.ChangeStateOfTiles((int)transform.position.x,
            (int)transform.position.y, Tile.TileStateEnum.full, this);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.normalized == Vector2.up)
        {
            sqParent.StopFalling();
        }
    }

    public void MakeSquareSleep()
    {
        sqParent.gameManager.ChangeStateOfTiles((int)transform.position.x,
            (int)transform.position.y, Tile.TileStateEnum.empty, null);
        gameObject.SetActive(false);
        sqParent.NotifyParent();
    }
    
}
