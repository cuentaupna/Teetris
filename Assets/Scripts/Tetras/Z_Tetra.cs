using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Tetra : Tetromino
{
    /// <summary>
    /// Constructor Z
    /// </summary>
    /// <param name="pGameManager"></param>
    public Z_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        TetrID = 7;
        arriba = new int[][] { new int[] { TetrID, TetrID, 0 }, new int[] { 0, TetrID, TetrID } };
        derecha = new int[][] { new int[] { 0, 0, TetrID }, new int[] { 0, TetrID, TetrID }, new int[] { 0, TetrID, 0 } };
        abajo = new int[][] { new int[] { TetrID, TetrID, 0 }, new int[] { 0, TetrID, TetrID } };
        izquierda = new int[][] { new int[] { 0, TetrID }, new int[] { TetrID, TetrID }, new int[] { TetrID, 0 } };
        shape = arriba;
    }
}
