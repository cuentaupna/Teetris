using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][] { new int[] { 7, 7, 0}, new int[] { 0, 7, 7}};
    readonly int[][] derecha = new int[][] { new int[] { 0, 0, 7}, new int[] { 0, 7, 7}, new int[] { 0, 7, 0}};
    readonly int[][] abajo = new int[][] { new int[] { 7, 7, 0}, new int[] { 0, 7, 7 }};
    readonly int[][] izquierda = new int[][] { new int[] { 0, 7}, new int[] { 7, 7}, new int[] { 7, 0}};
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 7;
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
