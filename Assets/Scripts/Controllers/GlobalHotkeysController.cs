using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalHotkeysController : MonoBehaviour
{
    public static GlobalHotkeysController Instance { get; private set; }
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

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
            SceneController.Instance.ReloadScene();

        if (Keyboard.current.escapeKey.wasPressedThisFrame & isActiveAndEnabled)
            GameStateController.Instance.TogglePause();

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            print(GameStateController.Instance.P_IsLevelClear);
            print(GameStateController.Instance.P_IsPlayerDead);
            print(GameStateController.Instance.P_IsGamePaused);
        }
    }
}
