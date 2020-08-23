using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public GameObject[] squares = new GameObject[4];
    protected Square[] squareScript = new Square[4];
    public enum TetraFace { Up, Left, Down, Right}
    public TetraFace face;
    public float timeToFall;
    protected Vector2 nexPos;
    public GameManager gameManager;
    private Coroutine routine;
    private int activeCounter;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        nexPos = transform.position;
        for(int i = 0; i < 4; ++i)
        {
            squareScript[i] = squares[i].GetComponent<Square>();
            squareScript[i].AssignParent(this);
        }
        routine = StartCoroutine(FallinRoutine());
        activeCounter = 4;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FallinRoutine()
    {
        for (; ;)
        {
            MoveParent(0, -1);
            yield return new WaitForSeconds(timeToFall);
        }
    }
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void MoveParent(int x, int y)
    {
        bool canMove = false;
        for(int i = 0; i < 4; ++i)
        {
            canMove = gameManager.CheckTile((int)squares[i].transform.position.x + x,
                (int)squares[i].transform.position.y + y);
            if (!canMove)
                break;
        }
        if (canMove)
        {
            nexPos.x += x;
            nexPos.y += y;
            transform.position = nexPos;
        }
    }

    public void StopFalling()
    {
        StopCoroutine(routine);
        for(int i = 0; i < 4; ++i)
        {
            squareScript[i].LandSquare();
        }
        gameObject.layer = LayerMask.NameToLayer("Landed");
    }
    public void Rotate(int p)
    {
        if (p == 0)
        {
            //Girar a la izquierda
            switch (face)
            {
                case TetraFace.Up:
                    RotateToDirection(TetraFace.Left);
                    break;
                case TetraFace.Left:
                    RotateToDirection(TetraFace.Down);
                    break;
                case TetraFace.Down:
                    RotateToDirection(TetraFace.Right);
                    break;
                case TetraFace.Right:
                    RotateToDirection(TetraFace.Up);
                    break;
            }
        }
        else
        {
            //Girar a la derecha
            switch (face)
            {
                case TetraFace.Up:
                    RotateToDirection(TetraFace.Right);
                    break;
                case TetraFace.Left:
                    RotateToDirection(TetraFace.Up);
                    break;
                case TetraFace.Down:
                    RotateToDirection(TetraFace.Left);
                    break;
                case TetraFace.Right:
                    RotateToDirection(TetraFace.Down);
                    break;
            }
        }
    }

    public void Reset()
    {
        RotateToDirection(TetraFace.Up);
        routine = StartCoroutine(FallinRoutine());
        gameObject.layer = LayerMask.NameToLayer("Falling");
        for (int i = 0; i < 4; ++i)
        {
            squareScript[i].ResetSquare();
        }
        activeCounter = 4;
    }
    public void NotifyParent()
    {
        --activeCounter;
        if(activeCounter == 0)
        {
            gameObject.SetActive(false);
        }
    }
    protected virtual void RotateToDirection(TetraFace newFace)
    {

    }
}
