using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Variables ////////////////////////////////////////////////
    /// </summary>
    public GameObject sq;
    public int[,] grill = new int[16, 10];
    List<Tetromino> ListadoDeTetriminosOAlgoAsi = new List<Tetromino>();
    Tetromino currentTetri;
    Tetromino nextTetri;
    public float timeToFall = 10f; //Tiempo en segundos
    public bool gameOver;
    public GameObject[,] sprites = new GameObject[16,10];
    private Coroutine rutina;

    /**
     * Metodos
    */

    /// <summary>
    /// Movemos currentTetri a la posicion newPos
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
    /// Movemos el Tetromino: -1 a la izquierda, 1 a la derecha
    /// </summary>
    /// <param name="pDirection"></param>
    public void MoveInHorizonalAxis(int pDirection)
    {
        int[] newPos = currentTetri.pos;
        newPos[1] -= pDirection ;
        MoveTetri(currentTetri, newPos);
    }
    /// <summary>
    /// Utilizamos este método para verificar si hay colisiones
    /// </summary>
    /// <param name="tetromino"></param>
    /// <param name="newPos"></param>
    /// <returns></returns>
    public bool CheckCollision(Tetromino tetromino, int[] newPos, int[][] shape = null)
    {
        //Debug.Log("             newPos " + newPos[0] + "    " + newPos[1]);
        if(shape == null)
        {
            shape = tetromino.shape;
        }
        if (newPos[0] >= (grill.GetLength(0) - shape.Length))
        {
            return false;
        }

        int max = 0;
        for (int i = 0; i < shape.Length; ++i)
        {
            if (max < shape[i].Length)
                max = shape[i].Length;
        }
        Debug.Log("MAX:" + max);
        Debug.Log("             NewPos: " + newPos[1]);
        Debug.Log("OP:" + (grill.GetLength(1) - max));
        if((newPos[1] < 0) || (newPos[1] >= (grill.GetLength(1) - max)))
        {
            return false;
        }
        for (int i = 0; i < shape.Length; ++i)
        {
            for (int j = 0; j < shape[i].Length; ++j)
            {
                if (shape[i][j] != 0)
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
                Debug.Log(tetromino.pos[0] + i);
                Debug.Log(tetromino.pos[1] + j);
                grill[tetromino.pos[0] + i, tetromino.pos[1] + j] += tetromino.shape[i][j];
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
            Tetromino xd = new L_Tetra(this);
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
        currentTetri = new O_Tetra(this);
        //REMOVE
        nextTetri = ListadoDeTetriminosOAlgoAsi[0];
        ListadoDeTetriminosOAlgoAsi.RemoveAt(0);
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
            ++newPos[0];
            if(!MoveTetri(currentTetri, newPos))
            {
                Land(currentTetri);
                //Debug.Log("Game Over");
                //gameOver = true;
                
                currentTetri = nextTetri;
                nextTetri = ListadoDeTetriminosOAlgoAsi[0];
                ListadoDeTetriminosOAlgoAsi.RemoveAt(0);
                if(!MoveTetri(currentTetri, new int[] { 0, 4 }))
                {
                    //GAME OVER
                    gameOver = true;
                    Debug.Log("Game OVer");
                }
                
            }
            CheckLines();
            //Debug.Log("Next Iter");
            //DrawGame(false);
            yield return new WaitForSeconds(timeToFall);
        }
    }
    public void DrawGame(bool drawTetri)
    {
        if (drawTetri)
        {
            for (int i = 0; i < grill.GetLength(0); ++i)
            {
                for (int j = 0; j < grill.GetLength(1); ++j)
                {
                    if (grill[i, j] != 0)
                    {
                        sprites[i, j].SetActive(true);
                    }
                }
            }
            if (currentTetri != null)
            {
                Debug.Log("Forma" + currentTetri.shape.Length);
                for (int i = 0; i < currentTetri.shape.Length; ++i)
                {
                    for (int j = 0; j < currentTetri.shape[i].Length; ++j)
                    {
                        //Debug.Log(tetromino.pos[0] + i);
                        //Debug.Log(tetromino.pos[1] + j);
                        if (currentTetri.shape[i][j] != 0)
                            sprites[currentTetri.pos[0] + i, currentTetri.pos[1] + j].SetActive(true);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < grill.GetLength(0); ++i)
            {
                for (int j = 0; j < grill.GetLength(1); ++j)
                {
                    sprites[i, j].SetActive(false);
                }
            }
        }
    }

    public void Update()
    {
        if (gameOver)
            StopCoroutine(rutina);
        DrawGame(false);
        DrawGame(true);

    }

    public void RotateTetri(bool pDirection)
    {
        currentTetri.Rotate(pDirection);
    }

    public void CheckLines()
    {
        List<int> xd = new List<int>();
        int contador;
        for (int i = 0; i < grill.GetLength(0); ++i)
        {
            contador = 0;
            for (int j = 0; j < grill.GetLength(1); ++j)
            {
                if (grill[i, j] != 0)
                    ++contador;
            }
            if (contador == grill.GetLength(1))
                xd.Add(i);
        }

        foreach (int item in xd)
        {
            for (int j = 0; j < grill.GetLength(1); ++j)
            {
                grill[item, j] = 0;
            }
            //Tenemos que copiar los números de las filas superiores a una inferior
            for (int i = item + 1; i < grill.GetLength(0); ++i)
            {
                for (int j = 0; j < grill.GetLength(1); ++j)
                {
                    grill[item - 1, j] = grill[item, j];
                }
            }
        }
    }
}
