using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Tetra : Tetromino
{
    protected override void RotateToDirection(TetraFace newFace)
    {
        bool canRotate = false;
        switch (newFace)
        {
            case TetraFace.Up:
                for (int i = 0; i < 4; ++i)
                {
                    canRotate = gameManager.CheckTile((int)transform.position.x,
                        (int)transform.position.y + i);
                    if (!canRotate)
                    {
                        break;
                    }
                }
                if (canRotate)
                {
                    face = TetraFace.Up;
                    for (int i = 0; i < 4; ++i)
                    {
                        squareScript[i].MoveSquare(0.5f, 0.5f + i);
                    }

                }
                break;
            case TetraFace.Left:
                for (int i = 0; i < 4; ++i)
                {
                    canRotate = gameManager.CheckTile((int)transform.position.x - 2 + i,
                        (int)transform.position.y);
                    if (!canRotate)
                    {
                        break;
                    }
                }
                if (canRotate)
                {
                    face = TetraFace.Left;
                    for (int i = 0; i < 4; ++i)
                    {
                        squareScript[i].MoveSquare(-1.5f + i, 0.5f);
                    }

                }
                break;
            case TetraFace.Down:
                for (int i = 0; i < 4; ++i)
                {
                    canRotate = gameManager.CheckTile((int)transform.position.x - 1,
                        (int)transform.position.y + i);
                    if (!canRotate)
                    {
                        break;
                    }
                }
                if (canRotate)
                {
                    face = TetraFace.Down;
                    for (int i = 0; i < 4; ++i)
                    {
                        squareScript[i].MoveSquare(-0.5f, 0.5f + i);
                    }

                }
                break;
            case TetraFace.Right:
                for (int i = 0; i < 4; ++i)
                {
                    canRotate = gameManager.CheckTile((int)transform.position.x - 2 + i,
                        (int)transform.position.y);
                    if (!canRotate)
                    {
                        break;
                    }
                }
                if (canRotate)
                {
                    face = TetraFace.Right;
                    for (int i = 0; i < 4; ++i)
                    {
                        squareScript[i].MoveSquare(-1.5f + i, 0.5f);
                    }

                }
                break;
        }
    }
    
}
