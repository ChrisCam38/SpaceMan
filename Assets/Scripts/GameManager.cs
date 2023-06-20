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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metodo encargado de iniciar la partida
    public void startGame() 
    {
   
    }

    //Metodo encargado de finalizar la partida
    public void GameOver()
    {

    }

    //Metodo para volver al menu
    public void BackToMenu()
    {

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
            //TODO: Preparar la escena para jugar
        }
        else if(newGameState == GameState.gameOver)
        {
            //TODO: Preparar el juego para gameover
        }

        this.currentGameState = newGameState;
    }
}
