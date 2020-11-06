using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject sq;
    int[,] grill = new int[16, 10];
    List<Tetromino> ListadoDeTetriminosOAlgoAsi = new List<Tetromino>();
    Tetromino currentTetri;
    Tetromino nextTetri;
    public float timeToFall = 60f; //Tiempo en segundos
    public bool gameOver;
    public GameObject[,] sprites = new GameObject[16,10];
    private Coroutine rutina;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nTetri"></param>
    /// <returns></returns>
    public bool MoveTetri(Tetromino nTetri, int[] newPos)
    {
        bool canMove = CheckCollision(nTetri, newPos);
        if (canMove)
        {
            nTetri.pos = newPos;
            //Creamos el Tetrimino
        }
        //Si es falso, el juego habrá acabado
        return canMove;
    }
    
    
    /// <summary>
    /// Utilizamos este método para verificar si hay colisiones
    /// </summary>
    /// <param name="tetromino"></param>
    /// <param name="newPos"></param>
    /// <returns></returns>
    public bool CheckCollision(Tetromino tetromino, int[] newPos)
    {
        if (newPos[0] >= grill.GetLength(0))
        {
            return false;
        }
        if(newPos[1] < 0 || newPos[1] >= grill.GetLength(1))
        {
            return false;
        }
        for (int i = 0; i < tetromino.shape.Length; ++i)
        {
            for (int j = 0; j < tetromino.shape[i].Length; ++j)
            {
                if(tetromino.shape[i][j] != 0)
                {
                    if(grill[newPos[0] + i, newPos[1] + j] != 0)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tetromino"></param>
    public void Land(Tetromino tetromino)
    {
        //Añadimos el Tetromino a la matriz
        for (int i = 0; i < tetromino.shape.Length; ++i)
        {
            for (int j = 0; j < tetromino.shape[i].Length; ++j)
            {
                grill[tetromino.pos[0] + i, tetromino.pos[j] + i] += tetromino.shape[i][j];
            }
        }
        //Verificamos si hay alguna línea a limpiar
    }
    /// <summary>
    /// 
    /// </summary>
    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Tetromino xd = new I_Tetra();
            ListadoDeTetriminosOAlgoAsi.Add(xd);
        }
        gameOver = false;
        Vector2 spritePosition = new Vector2(0, 0);
        for (int i = 0; i < sprites.GetLength(0); ++i)
        {
            for (int j = 0; j < sprites.GetLength(1); ++j)
            {
                sprites[i, j] = Instantiate(sq, spritePosition, Quaternion.identity);
                ++spritePosition.x;
                sprites[i, j].SetActive(false);
            }
            spritePosition.x = 0;
            ++spritePosition.y;
        }
        currentTetri = new O_Tetra();
        if (currentTetri == null)
        {
            Debug.Log("FUCK YOU");
            //currentTetri = ListadoDeTetriminosOAlgoAsi[0];
            //currentTetri = new O_Tetra();
            ListadoDeTetriminosOAlgoAsi.RemoveAt(0);
            nextTetri = ListadoDeTetriminosOAlgoAsi[0];
            ListadoDeTetriminosOAlgoAsi.RemoveAt(0);
        }
        MoveTetri(currentTetri, new int[] { 0, 4 });
        rutina = StartCoroutine(RutinaPrincipal());
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator RutinaPrincipal()
    {
        
        for(; ; )
        {
            
            int[] newPos = currentTetri.pos;
            Debug.Log(newPos);
            ++newPos[0];
            if(!MoveTetri(currentTetri, newPos))
            {
                Land(currentTetri);
                currentTetri = nextTetri;
                nextTetri = ListadoDeTetriminosOAlgoAsi[0];
                ListadoDeTetriminosOAlgoAsi.RemoveAt(0);
                if(!MoveTetri(currentTetri, new int[] { 0, 4 }))
                {
                    //GAME OVER
                    gameOver = true;
                }
            }
            yield return new WaitForSeconds(timeToFall);
        }
    }
    public void DrawGame()
    {
        for (int i = 0; i < grill.GetLength(0); ++i)
        {
            for (int j = 0; j < grill.GetLength(1); ++j)
            {
                if(grill[i,j] != 0)
                {
                    sprites[i, j].SetActive(true);
                }
            }
        }

        for (int i = currentTetri.pos[0]; i < currentTetri.shape.Length; ++i)
        {
            for (int j = currentTetri.pos[1]; j < currentTetri.shape[i].Length; ++j)
            {
                if (currentTetri.shape[i][j] != 0)
                {
                    sprites[i, j].SetActive(true);
                }
            }
        }
    }
    public void Update()
    {
        if(currentTetri != null)
            DrawGame();
        if (gameOver)
            StopCoroutine(rutina);
    }
}
