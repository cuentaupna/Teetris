using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][] { new int[] { 0, 0, 3}, new int[] { 3, 3, 3}};
    readonly int[][] derecha = new int[][] { new int[] { 3, 0}, new int[] { 3, 0}, new int[] { 3, 3}};
    readonly int[][] abajo = new int[][] { new int[] { 3, 3, 3}, new int[] { 3, 0, 0},};
    readonly int[][] izquierda = new int[][] { new int[] { 3, 3}, new int[] { 0, 3}, new int[] { 0, 3}};
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 3;
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
