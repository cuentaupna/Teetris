using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Tetra : Tetromino
{
    readonly int[][] arriba = new int[][] { new int[] { 2, 0, 0,}, new int[] { 2, 2, 2}};
    readonly int[][] derecha = new int[][] { new int[] { 2, 2}, new int[] { 2, 0}, new int[] { 2, 0}};
    readonly int[][] abajo = new int[][] { new int[] { 2, 2, 2}, new int[] { 0, 0, 2}};
    readonly int[][] izquierda = new int[][] { new int[] { 0, 2}, new int[] { 0, 2}, new int[] { 2, 2}};
    protected override void DoTheWork()
    {
        shape = arriba;
        TetrID = 2;
    }
    protected override void RotateToDirection(TetriFace nTetriFace)
    {
        facingDirection = nTetriFace;
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
    public J_Tetra() : base()
    { }
}
