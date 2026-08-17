using System;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private bool m_isPlayerDead;
    private bool m_isLevelClear;
    private bool m_isGamePaused;
    public bool P_IsPlayerDead => m_isPlayerDead;
    public bool P_IsLevelClear => m_isLevelClear;
    public bool P_IsGamePaused => m_isGamePaused;

    public static event Action OnGamePaused;

    public static GameStateController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        PlayerBehavior.OnDeath += PlayerDies;
        LevelController.OnLevelClear += LevelCleared;
    }

    private void OnDisable()
    {
        PlayerBehavior.OnDeath -= PlayerDies;
        LevelController.OnLevelClear -= LevelCleared;
    }

    private void LevelCleared() { m_isLevelClear = true; Time.timeScale = 0; }
    private void PlayerDies() { m_isPlayerDead = true; Time.timeScale = 0; }

    public void TogglePause()
    {
        if (m_isLevelClear | m_isPlayerDead) return;
        GetComponent<AudioHolder>().ActivateSound(0);
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
        m_isGamePaused = Time.timeScale == 0; 
        OnGamePaused?.Invoke();
    }

    public void ResetStates()
    {
        m_isLevelClear = false;
        m_isPlayerDead = false;
        m_isGamePaused = false;
    }
}
