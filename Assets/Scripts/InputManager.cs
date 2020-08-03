﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode DropKey = KeyCode.DownArrow;
    public KeyCode FasterKey = KeyCode.UpArrow;
    public KeyCode RotateRightKey = KeyCode.X;
    public KeyCode RotateLeftKey = KeyCode.Z;
    private bool moveRight;
    private bool moveLeft;
    private bool Drop;
    private bool Faster;
    private bool RotateRight;
    private bool RotateLeft;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MakeInputReal();
    }
    public void FixedUpdate()
    {
        
    }
    
    private void GetInput()
    {
        moveRight = Input.GetKeyDown(moveRightKey);
        moveLeft = Input.GetKeyDown(moveLeftKey);
        Drop = Input.GetKeyDown(DropKey);
        Faster = Input.GetKey(FasterKey);
        RotateRight = Input.GetKeyDown(RotateRightKey);
        RotateLeft = Input.GetKeyDown(RotateLeftKey);
    }
    private void MakeInputReal()
    {
        if (moveRight)
        {
            gameManager.MoveTetri(1, 0);
        }else if (moveLeft)
        {
            gameManager.MoveTetri(-1, 0);
        }
        if (RotateRight)
        {
            gameManager.RotateTetri(1);
        }else if (RotateLeft)
        {
            gameManager.RotateTetri(0);
        }
        if (Drop)
        {

        }
        if (Faster)
        {

        }
    }
}
