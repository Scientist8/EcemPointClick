using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameMotor : MonoBehaviour
{
    //===================================================================================

    public static GameMotor Instance { get; private set; }

    //===================================================================================

    public enum GameState
    {
        NONE,
        INITIALIZING,
        INITIALIZED,
        PREPARING_NEW_GAME,
        PLAYING,
        PLAYING_TUTORIAL,
        PAUSED,
        FINISHED_WAITING_USER_ACTION,
        FINISHED,
        RESUMING,
        REVIVEING,
        READY_TO_RUN,
        STARTING_TO_RUN
    };

    [SerializeField] public GameState gameState;


    //===================================================================================

    public delegate void OnGameInitializeDelegate();
    public event OnGameInitializeDelegate OnGameInitialize;

    public delegate void OnStateChangeDelegate(GameState gsOld, GameState gsNew);
    public event OnStateChangeDelegate OnStateChange;

    public delegate void OnPrepareNewGameDelegate(bool bIsRematch = false);
    public event OnPrepareNewGameDelegate OnPrepareNewGame;

    public delegate void OnReadyToRunDelegate();
    public event OnReadyToRunDelegate OnReadyToRun;

    public delegate void OnStartGameDelegate();
    public event OnStartGameDelegate OnStartGame;

    public delegate void OnPauseGameDelegate();
    public event OnPauseGameDelegate OnPauseGame;

    public delegate void OnResumeGameDelegate();
    public event OnResumeGameDelegate OnResumeGame;

    public delegate void OnReviveGameDelegate();
    public event OnReviveGameDelegate OnReviveGame;

    public delegate void OnFinishGameWaitUserActionDelegate(bool bWin = true);
    public event OnFinishGameWaitUserActionDelegate OnFinishGameWaitUserAction;

    public delegate void OnFinishGameDelegate(bool bWin = true);
    public event OnFinishGameDelegate OnFinishGame;

    public delegate void OnExitGameDelegate();
    public event OnExitGameDelegate OnExitGame;



    //===================================================================================

    void Awake()
    {
        Application.targetFrameRate = 60;
        SingletonThisObject();
    }

    void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //===================================================================================

    public GameState GetState()
    {
        return gameState;
    }

    //===================================================================================

    public void SetState(GameState gs)
    {
        Debug.Log("<color='white'>GameMotor.SetState</color>: " + gs.ToString());

        GameState gsOld = GetState();
        GameState gsNew = gs;

        gameState = gsNew;

        OnStateChange?.Invoke(gsOld, gsNew);
    }

    //===================================================================================

    public void PrepareNewGame(bool bIsRematch = false)
    {
        Debug.Log("<color='cyan'>GameMotor.PrepareNewGame</color>");

        if (GetState() != GameState.READY_TO_RUN)
        {
            SetState(GameState.PREPARING_NEW_GAME);
            OnPrepareNewGame?.Invoke(bIsRematch);

            SetState(GameState.READY_TO_RUN);
            OnReadyToRun?.Invoke();
        }
    }

    //===================================================================================

    public void StartGame()
    {
        Debug.Log("<color='cyan'>GameMotor.StartGame</color>");

        if (GetState() == GameState.READY_TO_RUN)
        {
            SetState(GameState.STARTING_TO_RUN);
            OnStartGame?.Invoke();

            SetState(GameState.PLAYING);
        }
    }

    //===================================================================================

    public void StartGameInstantly(bool bIsRematch = false)
    {
        Debug.Log("<color='cyan'>GameMotor.StartGameInstantly</color>");

        PrepareNewGame(bIsRematch);

        StartGame();
    }

    //===================================================================================

    public void PauseGame()
    {
        Debug.Log("<color='cyan'>GameMotor.PauseGame</color>");

        if (IsPlaying())
        {
            SetState(GameState.PAUSED);

            OnPauseGame?.Invoke();
        }
    }

    //===================================================================================

    public void ResumeGame()
    {
        Debug.Log("<color='cyan'>GameMotor.ResumeGame</color>");

        if (GetState() == GameState.PAUSED)
        {
            SetState(GameState.RESUMING);
            OnResumeGame?.Invoke();

            SetState(GameState.PLAYING);
        }
    }

    //===================================================================================

    public void ReviveGame()
    {
        Debug.Log("<color='cyan'>GameMotor.ReviveGame</color>");

        if (GetState() == GameState.FINISHED_WAITING_USER_ACTION)
        {
            SetState(GameState.REVIVEING);
            OnReviveGame?.Invoke();

            SetState(GameState.PLAYING);
        }
    }

    //===================================================================================

    public void FinishGameWaitUserAction(bool bWin = true)
    {
        Debug.Log("<color='cyan'>GameMotor.FinishGameWaitUserAction</color>");

        if (GetState() != GameState.FINISHED_WAITING_USER_ACTION)
        {
            SetState(GameState.FINISHED_WAITING_USER_ACTION);
            OnFinishGameWaitUserAction?.Invoke(bWin);
        }
    }

    //===================================================================================

    public void FinishGame(bool bWin = true)
    {
        Debug.Log("<color='cyan'>GameMotor.FinishGame</color>");

        if (GetState() != GameState.FINISHED)
        {
            SetState(GameState.FINISHED);
            OnFinishGame?.Invoke(bWin);
        }
    }

    //===================================================================================

    public void ExitGame(bool bPrepareNewGame = true)
    {
        Debug.Log("<color='cyan'>GameMotor.ExitGame</color>");

        SetState(GameState.NONE);
        OnExitGame?.Invoke();

        if (bPrepareNewGame)
        {
            PrepareNewGame();
        }
    }

    //===================================================================================

    public bool IsPlaying()
    {
        //Debug.Log("<color='cyan'>GameMotor.IsPlaying</color>");

        GameState gsCurrent = GetState();
        if (gsCurrent == GameState.PLAYING || gsCurrent == GameState.PLAYING_TUTORIAL)
        {
            return true;
        }

        return false;
    }
}

//===================================================================================