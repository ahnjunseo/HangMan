using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public WordManager WordManager { get; private set; }
    public UIManager UIManager { get; private set; }
    public GameStateManager GameStateManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        WordManager = GetComponentInChildren<WordManager>();
        UIManager = GetComponentInChildren<UIManager>();
        GameStateManager = GetComponentInChildren<GameStateManager>();
    }
}
