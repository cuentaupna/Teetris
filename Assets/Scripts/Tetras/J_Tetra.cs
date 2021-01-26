using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Tetra : Tetromino
{
    /// <summary>
    /// Constructor J
    /// </summary>
    /// <param name="pGameManager"></param>
    public J_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        TetrID = 2;
        arriba = new int[][] { new int[] { TetrID, 0, 0, }, new int[] { TetrID, TetrID, TetrID } };
        derecha = new int[][] { new int[] { TetrID, TetrID }, new int[] { TetrID, 0 }, new int[] { TetrID, 0 } };
        abajo = new int[][] { new int[] { TetrID, TetrID, TetrID }, new int[] { 0, 0, TetrID } };
        izquierda = new int[][] { new int[] { 0, TetrID }, new int[] { 0, TetrID }, new int[] { TetrID, TetrID } };
        shape = arriba;
    }
}
