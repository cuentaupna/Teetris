using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Tetra : Tetromino
{
    protected override void RotateToDirection(TetraFace newFace)
    {
        squareScript[0].MoveSquare(0.5f, 0.5f);
        squareScript[1].MoveSquare(1.5f, 0.5f);
        squareScript[2].MoveSquare(0.5f, 1.5f);
        squareScript[3].MoveSquare(1.5f, 1.5f);
    }
}
