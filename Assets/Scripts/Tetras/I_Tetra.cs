using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][]{ new int []{ 1, 1, 1, 1 } };
    readonly int[][] derecha = new int[][] { new int[] {1}, new int[] {1}, new int[] {1} , new int[] {1}};
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 1;
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
                shape = arriba;
                break;
            case TetriFace.Left:
                shape = derecha;
                break;
        }
    }
}
