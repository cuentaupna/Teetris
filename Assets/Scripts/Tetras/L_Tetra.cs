using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Tetra : Tetromino
{
    protected override void RotateToDirection(TetraFace newFace)
    {
        bool canRotate = false;
        switch (newFace)
        {
            case TetraFace.Up:
                canRotate = gameManager.CheckTile((int)transform.position.x + 1,
                    (int)transform.position.y);
                if (canRotate)
                {
                    for (int i = 0; i < 3; ++i)
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
                        squareScript[3].MoveSquare(0.5f, 0.5f);
                        for (int i = 0; i < 3; ++i)
                        {
                            squareScript[i].MoveSquare(1.5f, 0.5f + i);
                        }
                    }

                }
                break;
            case TetraFace.Left:
                canRotate = gameManager.CheckTile((int)transform.position.x + 2,
                    (int)transform.position.y);
                if (canRotate)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        canRotate = gameManager.CheckTile((int)transform.position.x + i,
                        (int)transform.position.y + 1);
                        if (!canRotate)
                        {
                            break;
                        }
                    }
                    if (canRotate)
                    {
                        face = TetraFace.Left;
                        squareScript[3].MoveSquare(2.5f, 0.5f);
                        for (int i = 0; i < 3; ++i)
                        {
                            squareScript[i].MoveSquare(0.5f + i, 1.5f);
                        }
                    }

                }

                break;
            case TetraFace.Down:
                canRotate = gameManager.CheckTile((int)transform.position.x + 2,
                    (int)transform.position.y + 2);
                if (canRotate)
                {
                    for (int i = 0; i < 3; ++i)
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
                        face = TetraFace.Down;
                        squareScript[3].MoveSquare(2.5f, 2.5f);
                        for (int i = 0; i < 3; ++i)
                        {
                            squareScript[i].MoveSquare(1.5f, 0.5f + i);
                        }
                    }

                }
                break;
            case TetraFace.Right:
                canRotate = gameManager.CheckTile((int)transform.position.x,
                    (int)transform.position.y + 2);
                if (canRotate)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        canRotate = gameManager.CheckTile((int)transform.position.x + i,
                        (int)transform.position.y + 1);
                        if (!canRotate)
                        {
                            break;
                        }
                    }
                    if (canRotate)
                    {
                        face = TetraFace.Right;
                        squareScript[3].MoveSquare(0.5f, 2.5f);
                        for (int i = 0; i < 3; ++i)
                        {
                            squareScript[i].MoveSquare(0.5f + i, 1.5f);
                        }
                    }

                }
                break;
        }
    }
}
