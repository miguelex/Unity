using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inTheGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;

    public int collectedCoin = 0;
    
    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        currentGameState = GameState.menu;
        menuCanvas.enabled = true;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;
    }

    private void Update()
    {
        /*if (Input.GetButtonDown("s"))
        {
            if (currentGameState != GameState.inTheGame)
            {
                StartGame();
            }
        }*/
    }

    // Se llama para iniciar el juego
    public void StartGame()
    {
        ChangeGameState(GameState.inTheGame);
        LevelGenerator.sharedInstance.GenerateInitialBlock();
        PlayerController.sharedInstance.StartGame();
        ViewInGame.sharedInstance.UpdateHigScoreLabel();
        collectedCoin = 0;
        ViewInGame.sharedInstance.coinsLabel.text = "0";
    }

    // Se llama cuando se va a termianr el jeugo
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllTheBlocks();
        ChangeGameState(GameState.gameOver);
        ViewGameOver.sharedInstance.UpdateUI();
    }

    // Se llama para ir de vuelta al menu principal
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }

    void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // La escena de Unity debe mostrar el menu principal
            menuCanvas.enabled = true;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        } else if (newGameState == GameState.inTheGame)
        {
            // La escena mostrara el juego en si
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        } else if (newGameState == GameState.gameOver)
        {
            // La escena mostrara la pantalla final
            menuCanvas.enabled = false;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
        
        currentGameState = newGameState;
    }

    public void CollectCoin()
    {
        collectedCoin++;
        ViewInGame.sharedInstance.UpdateCoinLabe();
    }
}
