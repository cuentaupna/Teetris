using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][] { new int[] { 5, 5}, new int[] { 5, 5}};
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 5;
    }
    protected override void RotateToDirection(TetriFace nTetriFace)
    {

    }
}
