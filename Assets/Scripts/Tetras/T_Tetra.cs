using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Tetra : Tetromino
{
    /// <summary>
    /// Constructor T
    /// </summary>
    /// <param name="pGameManager"></param>
    public T_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        TetrID = 6;
        arriba = new int[][] { new int[] { 0, TetrID, 0 }, new int[] { TetrID, TetrID, TetrID } };
        derecha = new int[][] { new int[] { TetrID, 0 }, new int[] { TetrID, TetrID }, new int[] { TetrID, 0 } };
        abajo = new int[][] { new int[] { TetrID, TetrID, TetrID }, new int[] { 0, TetrID, 0 } };
        izquierda = new int[][] { new int[] { 0, TetrID }, new int[] { TetrID, TetrID }, new int[] { 0, TetrID } };
        shape = arriba;
    }
}
