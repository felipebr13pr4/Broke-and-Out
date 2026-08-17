using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "MainMenu") return;

        if (Keyboard.current.rKey.wasPressedThisFrame)
            SceneController.Instance.ReloadScene();

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            GameStateController.Instance.TogglePause();
    }
}
