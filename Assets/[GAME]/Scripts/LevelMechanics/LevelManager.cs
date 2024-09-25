using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


[DefaultExecutionOrder(-1)]
public class LevelManager : MonoBehaviour
{
    //===================================================================================

    public static LevelManager Instance { get; private set; }

    //===================================================================================



    //===================================================================================

    [HideInInspector]
    public LevelController controller;
    [HideInInspector]
    public LevelData datas;

    [Space]

    private int level;

    //===================================================================================

    void Awake()
    {
        SingletonThisObject();

        controller = gameObject.AddComponent<LevelController>();
        datas = gameObject.AddComponent<LevelData>();
    }

    //===================================================================================

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

    void OnEnable()
    {
        GameMotor.Instance.OnGameInitialize += OnGameInitialize;
        GameMotor.Instance.OnPrepareNewGame += OnPrepareNewGame;
        GameMotor.Instance.OnStartGame += OnStartGame;
        GameMotor.Instance.OnPauseGame += OnPauseGame;
        GameMotor.Instance.OnResumeGame += OnResumeGame;
        GameMotor.Instance.OnReviveGame += OnReviveGame;
        GameMotor.Instance.OnFinishGameWaitUserAction += OnFinishGameWaitUserAction;
        GameMotor.Instance.OnFinishGame += OnFinishGame;
        GameMotor.Instance.OnExitGame += OnExitGame;

        controller.OnLevelFailed += OnLevelFailed;
        controller.OnLevelCompleted += OnLevelCompleted;
        controller.OnLevelDraw += OnLevelDraw;
        controller.OnStageCompleted += OnStageCompleted;
        controller.OnStageChanged += OnStageChanged;
        controller.OnLevelChanged += OnLevelChanged;
        // controller.OnLevelProgressValueChanged += OnLevelProgressValueChanged;
        controller.OnScoreValueUpdated += OnScoreValueChanged;
    }

    //===================================================================================

    void OnDisable()
    {
        GameMotor.Instance.OnGameInitialize -= OnGameInitialize;
        GameMotor.Instance.OnPrepareNewGame -= OnPrepareNewGame;
        GameMotor.Instance.OnStartGame -= OnStartGame;
        GameMotor.Instance.OnPauseGame -= OnPauseGame;
        GameMotor.Instance.OnResumeGame -= OnResumeGame;
        GameMotor.Instance.OnReviveGame -= OnReviveGame;
        GameMotor.Instance.OnFinishGameWaitUserAction -= OnFinishGameWaitUserAction;
        GameMotor.Instance.OnFinishGame -= OnFinishGame;
        GameMotor.Instance.OnExitGame -= OnExitGame;

        controller.OnLevelFailed -= OnLevelFailed;
        controller.OnLevelCompleted -= OnLevelCompleted;
        controller.OnLevelDraw -= OnLevelDraw;
        controller.OnStageCompleted -= OnStageCompleted;
        controller.OnStageChanged -= OnStageChanged;
        controller.OnLevelChanged -= OnLevelChanged;
        // controller.OnLevelProgressValueChanged -= OnLevelProgressValueChanged;
        controller.OnScoreValueUpdated -= OnScoreValueChanged;
    }

    //===================================================================================

    void Start()
    {
        GameMotor.Instance.SetState(GameMotor.GameState.INITIALIZED);

        //GameMotor.Instance.PrepareNewGame();
        GameMotor.Instance.StartGameInstantly();
    }

    //===================================================================================
    //
    // Event Handlers - GameMotor
    //

    private void OnExitGame()
    {
    }

    //===================================================================================

    private void OnFinishGame(bool bWin = true)
    {

    }

    //===================================================================================

    private void OnFinishGameWaitUserAction(bool bWin = true)
    {
    }

    //===================================================================================

    private void OnReviveGame()
    {
    }

    //===================================================================================

    private void OnResumeGame()
    {
    }

    //===================================================================================

    private void OnPauseGame()
    {
    }

    //===================================================================================

    private void OnStartGame()
    {

    }

    //===================================================================================

    private void OnPrepareNewGame(bool bIsRematch = false)
    {
        // level = LevelManager.Instance.datas.GetCurrentLevel();
        PrepareLevel();
    }

    //===================================================================================

    public void OnGameInitialize()
    {
    }

    //===================================================================================


    //===================================================================================
    //
    // Event Handlers - LevelEventsManager
    //

    private void OnLevelFailed()
    {
        GameMotor.Instance.FinishGame(false);
    }

    //===================================================================================

    private void OnLevelCompleted()
    {

        GameMotor.Instance.FinishGame();

    }

    //===================================================================================

    private void OnLevelDraw()
    {
        GameMotor.Instance.FinishGame();
    }

    //===================================================================================

    public void OnStageCompleted(int nStage)
    {
    }

    //===================================================================================

    public void OnStageChanged(int nStage)
    {
    }

    //===================================================================================

    public void OnLevelChanged(int nLevel)
    {
    }

    //===================================================================================

    //===================================================================================

    public void OnScoreValueChanged()
    {
    }

    //===================================================================================



    //===================================================================================
    //
    // LEVEL MECHANICS
    //

    void PrepareLevel()
    {
        // Debug.Log(Time.time + " <color='white'>Current Level</color>: " + datas.nLevelNumber);

        ClearPreviousLevel();

        CreateLevelObjects();
    }

    //===================================================================================

    void ClearPreviousLevel()
    {
        ResetLevelData();

        ClearPreviousLevelObjects();
    }

    //===================================================================================

    void ResetLevelData()
    {
    }

    //===================================================================================

    void ClearPreviousLevelObjects()
    {
        // PoolingManager.Instance.ReleaseAllPooledObjects();

        // // clear prev. level environment
    }

    //===================================================================================

    void CreateLevelObjects()
    {
        
    }

    //===================================================================================



    //===================================================================================

 

    //===================================================================================

    

    //===================================================================================

    public void RestartGame()
    {
        //PoolingManager.Instance.ReleaseAllPooledObjects();
        GameMotor.Instance.StartGameInstantly();
    }


}