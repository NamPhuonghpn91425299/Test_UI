using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;
    private void Awake()
    {
       Instance = this;
    }
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }
    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeros();
                break;
            case GameState.SpawnEnemies:
               UnitManager.Instance.SpawnEnemy();
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }

    }




    public enum GameState
    {
        GenerateGrid = 0,
        SpawnHeroes = 1,
        SpawnEnemies = 2,
        HeroesTurn = 3,
        EnemiesTurn = 4
    }
}
