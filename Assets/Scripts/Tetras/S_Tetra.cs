using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Tetra : Tetromino
{
    /// <summary>
    /// Constructor S
    /// </summary>
    /// <param name="pGameManager"></param>
    public S_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        
        TetrID = 5;
        arriba = new int[][] { new int[] { 0, TetrID, TetrID }, new int[] { TetrID, TetrID, 0 } };
        derecha = new int[][] { new int[] { TetrID, 0 }, new int[] { TetrID, TetrID }, new int[] { 0, TetrID } };
        abajo = new int[][] { new int[] { 0, TetrID, TetrID, 0 }, new int[] { TetrID, TetrID, 0, 0 } };
        izquierda = new int[][] { new int[] { TetrID, 0 }, new int[] { TetrID, TetrID }, new int[] { TetrID, 0 } };
        shape = arriba;
    }
}
