using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //===================================================================================

    //
    // Level
    //
    public delegate void OnLevelFailedDelegate();
    public event OnLevelFailedDelegate OnLevelFailed;

    public delegate void OnLevelCompletedDelegate();
    public event OnLevelCompletedDelegate OnLevelCompleted;

    public delegate void OnLevelDrawDelegate();
    public event OnLevelDrawDelegate OnLevelDraw;

    public delegate void OnStageCompletedDelegate(int nStage);
    public event OnStageCompletedDelegate OnStageCompleted;

    public delegate void OnStageChangedDelegate(int nStage);
    public event OnStageChangedDelegate OnStageChanged;

    public delegate void OnLevelChangedDelegate(int nLevel);
    public event OnLevelChangedDelegate OnLevelChanged;

    //
    // Generic
    //
    public delegate void OnLevelProgressValueChangedDelegate(float fMin, float fMax, float fVal);
    public event OnLevelProgressValueChangedDelegate OnLevelProgressValueChanged;

    public delegate void OnScoreValueChangedDelegate();
    public event OnScoreValueChangedDelegate OnScoreValueUpdated;

    public delegate void OnDiamondAmountChangedDelegate(int amount);
    public event OnDiamondAmountChangedDelegate OnDiamondAmountChanged;
    
    //=================================================================

    private bool isLevelEnded;
    private int goldAmount;

    //===================================================================================
    private void OnEnable()
    {
        GameMotor.Instance.OnPrepareNewGame += OnPrepareNewGame;
    }
    private void OnDisable()
    {
        GameMotor.Instance.OnPrepareNewGame -= OnPrepareNewGame;
    }


    private void OnPrepareNewGame(bool bIsRematch = false)
    {
        // goldAmount = PlayerPrefs.GetInt("gold");
        // ChangeGoldAmount(goldAmount);

        isLevelEnded = false;
    }

    public void FailLevel()
    {
        if (!isLevelEnded)
        {
            isLevelEnded = true;
            Debug.Log("<color='purple'>LevelEventsManager OnLevelFailed</color>");
            OnLevelFailed?.Invoke();

            // GameMotor.Instance.FinishGame(false);
        }
    }

    //===================================================================================

    public void CompleteLevel()
    {
        if (!isLevelEnded)
        {
            PlayerPrefs.SetInt("gold", goldAmount);
            isLevelEnded = true;
            Debug.Log("<color='purple'>LevelEventsManager OnLevelCompleted</color>");
            OnLevelCompleted?.Invoke();
        }

    }

    //===================================================================================

    public void DrawLevel()
    {
        if (!isLevelEnded)
        {
            isLevelEnded = true;
            Debug.Log("<color='purple'>LevelEventsManager OnLevelDraw</color>");
            OnLevelDraw?.Invoke();
        }
    }

    //===================================================================================

    public void CompleteStage(int nStage)
    {
        Debug.Log("<color='purple'>LevelEventsManager OnStageCompleted: </color>" + nStage);

        OnStageCompleted?.Invoke(nStage);
    }

    //===================================================================================

    public void ChangeStage(int nStage)
    {
        Debug.Log("<color='purple'>LevelEventsManager OnStageChanged: </color>" + nStage);

        OnStageChanged?.Invoke(nStage);
    }

    //===================================================================================

    public void ChangeLevel(int nLevel)
    {
        Debug.Log("<color='purple'>LevelEventsManager OnLevelChanged: </color>" + nLevel);

        OnLevelChanged?.Invoke(nLevel);
    }

    //===================================================================================


    //===================================================================================

    // public void UpdateScoreValue()
    // {
    //     //Debug.Log("<color='purple'>ScoreValueChanged</color>");

    //     OnScoreValueUpdated?.Invoke();
    // }

    // public void GoldIncreased(int amount)
    // {
    //     goldAmount += amount;
    //     ChangeGoldAmount(goldAmount);
    // }

    // private void ChangeGoldAmount(int amount)
    // {
    //     OnDiamondAmountChanged?.Invoke(amount);
    // }

    //  public void PlayerTakesExp(int takenExpPoints)
    // {
    //     experiencePoints += takenExpPoints;

    //     if (experiencePoints >= neededExp)
    //     {
    //         InvokeLevelUp();
    //         experiencePoints = 0;
    //         neededExp += 5;
    //         playerLevel++;
    //     }

    //     OnPlayerGetsExp?.Invoke();
    // }
    // public void InvokeLevelUp()
    // {
    //     Debug.Log("Player Leveled Up");
    //     OnLeveledUp?.Invoke();
    //     GameMotor.Instance.PauseGame();
    // }


}
