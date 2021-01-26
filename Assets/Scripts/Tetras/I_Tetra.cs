using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Tetra : Tetromino
{
    /// <summary>
    /// Constructor I
    /// </summary>
    /// <param name="pGameManager"></param>
    public I_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        TetrID = 1;
        arriba = new int[][] { new int[] { TetrID, TetrID, TetrID, TetrID } };
        derecha = new int[][] { new int[] { TetrID }, new int[] { TetrID }, new int[] { TetrID }, new int[] { TetrID } };
        abajo = arriba;
        derecha = izquierda;
        shape = arriba;
    }
}
