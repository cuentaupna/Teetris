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
    }
    
    protected virtual void RotateToDirection(TetriFace nTetriFace)
    {

    }
    protected virtual void DoTheWork()
    {

    }
 
    /// <summary>
    /// Constructor
    /// </summary>
    public Tetromino()
    {
        DoTheWork();
    }
}
