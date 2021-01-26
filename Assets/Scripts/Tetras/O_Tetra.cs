using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Tetra : Tetromino
{
    /// <summary>
    /// Constructor O
    /// </summary>
    public O_Tetra(GameManager pGameManager) : base(pGameManager)
    {
        TetrID = 4;
        arriba = new int[][] { new int[] { TetrID, TetrID }, new int[] { TetrID, TetrID } };
        abajo = arriba;
        izquierda = arriba;
        derecha = arriba;
        shape = arriba;
    }
}
