using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tetromino
{
    public int TetrID;
    public int[][] shape;
    public int[] pos = new int[2];  //Usamos 0 para indicar la fila y 1 para indicar la columna
    public enum TetriFace { Up, Left, Down, Right }
    public TetriFace facingDirection;

    protected GameManager gameManager;

    protected int[][] arriba;
    protected int[][] derecha;
    protected int[][] abajo;
    protected int[][] izquierda;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rotationSense"></param>
    public void Rotate(bool rotationSense)
    {
        if (rotationSense)
        {
            //Girar a la izquierda
            switch (facingDirection)
            {
                case TetriFace.Up:
                    RotateToDirection(TetriFace.Left);
                    break;
                case TetriFace.Left:
                    RotateToDirection(TetriFace.Down);
                    break;
                case TetriFace.Down:
                    RotateToDirection(TetriFace.Right);
                    break;
                case TetriFace.Right:
                    RotateToDirection(TetriFace.Up);
                    break;
            }
        }
        else
        {
            //Girar a la derecha
            switch (facingDirection)
            {
                case TetriFace.Up:
                    RotateToDirection(TetriFace.Right);
                    break;
                case TetriFace.Left:
                    RotateToDirection(TetriFace.Up);
                    break;
                case TetriFace.Down:
                    RotateToDirection(TetriFace.Left);
                    break;
                case TetriFace.Right:
                    RotateToDirection(TetriFace.Down);
                    break;
            }
        }
    }
    
    private void RotateToDirection(TetriFace nTetriFace)
    {
        int[][] newShape = null;
        switch (nTetriFace)
        {
            case TetriFace.Up:
                newShape = arriba;
                break;
            case TetriFace.Right:
                newShape = derecha;
                break;
            case TetriFace.Down:
                newShape = abajo;
                break;
            case TetriFace.Left:
                newShape = izquierda;
                break;
        }
        if (gameManager.CheckCollision(this, pos, newShape))
        {
            facingDirection = nTetriFace;
            shape = newShape;
        }
    }

 
    /// <summary>
    /// Constructor
    /// </summary>
    public Tetromino(GameManager pGameManager)
    {
        gameManager = pGameManager;
    }

    
}
