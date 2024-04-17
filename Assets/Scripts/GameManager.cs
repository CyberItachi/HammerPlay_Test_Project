using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> StateChanged;

    public GameState state;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.gameStart:
                HandleGameStart(); 
                break;
            case GameState.playerTurn:
                HandlePlayerTurn();
                break;
            case GameState.enemyTurn:
                HandleEnemyTurn();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        StateChanged?.Invoke(state);
    }

    void HandleGameStart()
    {

    }
    void HandlePlayerTurn()
    {

    }
    void HandleEnemyTurn()
    {

    }
}

public enum GameState
{
    gameStart,
    playerTurn,
    enemyTurn,
}