using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image hangmanImage;
    [SerializeField] private TMP_Text wordTmp;
    [SerializeField] private List<Sprite> hangmanSprites;
    [SerializeField] private TMP_Text lifeTmp;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverAnswerTmp;
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private TMP_Text clearAnswerTmp;
    [SerializeField] private TMP_Text categoryTmp;

    public void SetWordBase(string word)
    {
        wordTmp.text = ReplaceString(word);

        string ReplaceString(string targetword)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i<targetword.Length; i++)
            {
                if (char.IsWhiteSpace(targetword[i]))
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append("_");
                }
            }
            return sb.ToString();
        }
    }

    public bool ShowChar(List<int> indexes, char value)
    {
        foreach (int index in indexes) 
        {
            wordTmp.text = wordTmp.text.Remove(index, 1).Insert(index, value.ToString());
        }

        return wordTmp.text.Contains("_");
    }

    public void SetCategory(string st)
    {
        categoryTmp.text = "林力 : " + st;
    }

    public void SetHangMan(int remainLife)
    {
        hangmanImage.sprite = hangmanSprites[remainLife];
        lifeTmp.text = "巢篮 格见 : " + remainLife.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowAnswerGameOver()
    {
        gameOverAnswerTmp.gameObject.SetActive(true);
        gameOverAnswerTmp.maxVisibleCharacters = 5;
        string s = DataManager.Instance.words[DataManager.Instance.wordIndex].word;
        gameOverAnswerTmp.text = "沥翠 : " + s;
        StartCoroutine(type(s));
        
        IEnumerator type(string w)
        {
            foreach(char c in w)
            {
                yield return new WaitForSeconds(0.2f);
                gameOverAnswerTmp.maxVisibleCharacters++;
            }
        }
    }

    public void ShowClearPanel()
    {
        clearPanel.SetActive(true);
        ShowAnswerClear();
    }

    public void ShowAnswerClear()
    {
        clearAnswerTmp.text = DataManager.Instance.words[DataManager.Instance.wordIndex-1].word;
    }

    public void InputFieldClear(TMP_InputField inputField)
    {
        inputField.text = "";
    }
}
