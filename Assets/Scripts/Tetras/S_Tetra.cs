using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Tetra : Tetromino
{
    protected override void RotateToDirection(TetraFace newFace)
    {
        switch (newFace)
        {
            case TetraFace.Up:
                if(MakeItVertical())
                    face = TetraFace.Up;
                break;
            case TetraFace.Left:
                if(MakeItHorizontal())
                    face = TetraFace.Left;
                break;
            case TetraFace.Down:
                if (MakeItVertical())
                    face = TetraFace.Down;
                break;
            case TetraFace.Right:
                if (MakeItHorizontal())
                    face = TetraFace.Right;
                break;
        }
    }
    private bool MakeItHorizontal()
    {
        bool canRotate = false;
        for (int i = 0; i < 2; ++i)
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
            for (int i = 0; i < 2; ++i)
            {
                canRotate = gameManager.CheckTile((int)transform.position.x - 1 + i,
                    (int)transform.position.y + 1);
                if (!canRotate)
                {
                    break;
                }
            }
            if (canRotate)
            {
                for (int i = 0; i < 2; ++i)
                {
                    squareScript[i].MoveSquare(-1.5f + i, 0.5f);
                }
                for (int i = 2; i < 4; ++i)
                {
                    squareScript[i].MoveSquare(-2.5f + i, 1.5f);
                }
            }
        }
        return canRotate;
    }
    private bool MakeItVertical()
    {
        bool canRotate = false;
        for (int i = 0; i < 2; ++i)
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
            for (int i = 0; i < 2; ++i)
            {
                canRotate = gameManager.CheckTile((int)transform.position.x - 1,
                    (int)transform.position.y + i + 1);
                if (!canRotate)
                {
                    break;
                }
            }
            if (canRotate)
            {
                
                for (int i = 0; i < 2; ++i)
                {
                    squareScript[i].MoveSquare(0.5f, 0.5f + i);
                }
                for (int i = 2; i < 4; ++i)
                {
                    squareScript[i].MoveSquare(-0.5f, -0.5f + i);
                }
            }
        }
        return canRotate;
    }
}
