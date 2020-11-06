using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][] { new int[] { 0, 6, 0}, new int[] { 6, 6, 6} };
    readonly int[][] derecha = new int[][] { new int[] { 6, 0}, new int[] { 6, 6 }, new int[] { 6, 0} };
    readonly int[][] abajo = new int[][] { new int[] { 6, 6, 6}, new int[] { 0, 6, 0}};
    readonly int[][] izquierda = new int[][] { new int[] { 0, 6}, new int[] { 6, 6}, new int[] { 0, 6} };
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 6;
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
