using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Tetra : Tetromino
{
    /// <summary>
    /// Constructor L
    /// </summary>
    /// <param name="pGameManager"></param>
    public L_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        TetrID = 3;
        arriba = new int[][] { new int[] { 0, 0, TetrID }, new int[] { TetrID, TetrID, TetrID } };
        derecha = new int[][] { new int[] { TetrID, 0 }, new int[] { TetrID, 0 }, new int[] { TetrID, TetrID } };
        abajo = new int[][] { new int[] { TetrID, TetrID, TetrID }, new int[] { TetrID, 0, 0 }, };
        izquierda = new int[][] { new int[] { TetrID, TetrID }, new int[] { 0, TetrID }, new int[] { 0, TetrID } };
        shape = arriba;
    }
}
