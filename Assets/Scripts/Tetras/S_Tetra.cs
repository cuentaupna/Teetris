using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][] { new int[] { 0, 4, 4}, new int[] { 4, 4, 0} };
    readonly int[][] derecha = new int[][] { new int[] { 4, 0}, new int[] { 4, 4}, new int[] { 0, 4} };
    readonly int[][] abajo = new int[][] { new int[] { 0, 4, 4, 0 }, new int[] { 4, 4, 0, 0 } };
    readonly int[][] izquierda = new int[][] { new int[] { 4, 0}, new int[] { 4, 4}, new int[] { 4, 0} };
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 4;
    }
    protected override void RotateToDirection(TetriFace nTetriFace)
    {
        switch (nTetriFace)
        {
            case TetriFace.Up:
                shape = arriba;
                break;
            case TetriFace.Right:
                shape = derecha;
                break;
            case TetriFace.Down:
                shape = abajo;
                break;
            case TetriFace.Left:
                shape = izquierda;
                break;
        }
    }
}
