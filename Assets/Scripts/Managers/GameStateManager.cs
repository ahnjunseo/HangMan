using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Setting,
    ChooseWaiting,
    ChooseProcessing,
    GameOver,
    Clear,
}

public class GameStateManager : MonoBehaviour
{
    private UIManager uIManager;
    private DataManager dataManager;
    private WordManager wordManager;

    public GameState NowGameState { get; private set; }
    public int NowRemainLife { get; private set; }

    private void Start()
    {
        uIManager = GameManager.Instance.UIManager;
        dataManager = DataManager.Instance;
        wordManager = GameManager.Instance.WordManager;
        
        NowGameState = GameState.Setting;
        NowRemainLife = 8;
        uIManager.SetHangMan(NowRemainLife);
        (string word, string category) ss = dataManager.words[dataManager.wordIndex];
        wordManager.SetWord(ss.word);
        uIManager.SetCategory(ss.category);
        NowGameState = GameState.ChooseWaiting;
    }

    public void SetGameState(GameState state)
    {
        NowGameState = state;
    }

    public void LoseLife()
    {
        NowRemainLife--;
        uIManager.SetHangMan(NowRemainLife);
        if (NowRemainLife == 0)
        {
            GameOver();
        }
        else
        {
            SetGameState(GameState.ChooseWaiting);
        }
    }

    public void GameOver()
    {
        SetGameState(GameState.GameOver);
        uIManager.ShowGameOverPanel();
    }

    public void StageClear()
    {
        SetGameState(GameState.Clear);
        dataManager.wordIndex++;
        uIManager.ShowClearPanel();
    }

    public void GoToNextQuestion()
    {
        if (NowGameState == GameState.GameOver)
        {
            dataManager.wordIndex++;
        }

        if (dataManager.wordIndex == dataManager.words.Count)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
        
    }

    public void OneMore()
    {
        NowGameState = GameState.ChooseWaiting;
        NowRemainLife = 1;
        uIManager.SetHangMan(NowRemainLife);
        uIManager.CloseGameOverPanel();
    }
}
