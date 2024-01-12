using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public string word = "";
    private UIManager uIManager;
    private GameStateManager gameStateManager;

    private void Start()
    {
        uIManager = GameManager.Instance.UIManager;
        gameStateManager = GameManager.Instance.GameStateManager;
    }

    public void SetWord(string wordData)
    {
        word = wordData;
        uIManager.SetWordBase(wordData);
    }

    public void CheckChar(char ch)
    {
        if (word.Contains(ch)) 
        {
            List<int> indexes = new List<int>();
            for(int i = 0; i<word.Length; i++)
            {
                if (word[i] == ch)
                {
                    indexes.Add(i);
                }
            }
            if (!uIManager.ShowChar(indexes, ch))
            {
                gameStateManager.StageClear();
            }
            else
            {
                gameStateManager.SetGameState(GameState.ChooseWaiting);
            }
        }
        else
        {
            gameStateManager.LoseLife();
        }
    }

    public void CheckWord(string text)
    {
        text = text.Trim().ToUpper();
        if (word == text)
        {
            gameStateManager.StageClear();
        }
        else
        {
            gameStateManager.LoseLife();
        }
    }
}
