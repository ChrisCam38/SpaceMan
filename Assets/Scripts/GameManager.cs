using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState //Variable de tipo enumerado sirve para
                      //asignar unos valores y seleccionar alguno de ellos
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu; //Variable que contiene el estado actual

    public static GameManager sharedInstance;

    private PlayerController controller;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        };
    }

    //Metodo encargado de iniciar la partida
    public void StartGame() 
    {
        SetGameState(GameState.inGame);
    }

    //Metodo encargado de finalizar la partida
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    //Metodo para volver al menu
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    //Metodo encargado de modificar el estado del juego, ej: cambia de menu --> estado de juego 

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO: Colocar la logica del menu
        }
        else if(newGameState == GameState.inGame)
        {
            controller.StartGame();
            //TODO: Preparar la escena para jugar
        }
        else if(newGameState == GameState.gameOver)
        {
            //TODO: Preparar el juego para gameover
        }

        this.currentGameState = newGameState;
    }
}
