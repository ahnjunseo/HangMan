using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlphabetButton : MonoBehaviour
{
    [SerializeField] private char alphabet;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        GetComponentInChildren<TMP_Text>().text = alphabet.ToString();
    }

    public void SendAlphabet()
    {
        button.interactable = false;
        if (GameManager.Instance.GameStateManager.NowGameState != GameState.ChooseWaiting)
        {
            button.interactable = true;
            return;
        }
        GameManager.Instance.GameStateManager.SetGameState(GameState.ChooseProcessing);
        GameManager.Instance.WordManager.CheckChar(alphabet);
    }
}
