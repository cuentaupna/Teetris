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
    protected GameManager gameManager;
    private Coroutine routine;
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
    /*
    protected virtual void FixedUpdate()
    {
        if (timer > timeToFall)
        {
            if (state == TetraState.Falling)
                MoveParent(0, -1);
            //transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            //RotateTe(-1);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    */
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void MoveParent(int x, int y)
    {
        nexPos.x += x;
        nexPos.y += y;
        transform.position = nexPos;
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
    }

    protected virtual void RotateToDirection(TetraFace newFace)
    {

    }
}
