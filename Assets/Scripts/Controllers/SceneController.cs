using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
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
        if (Keyboard.current.rKey.wasPressedThisFrame) ReloadScene();
        if (Keyboard.current.qKey.wasPressedThisFrame)
        { if (Time.timeScale <= 0.1f) return; Time.timeScale -= 0.1f; }
        if (Keyboard.current.eKey.wasPressedThisFrame) Time.timeScale += 0.1f;
    }

    public void LoadScene(SceneType type)
    {
        string sceneToLoad = type switch
        {
            SceneType.Game => "MainGame",
            SceneType.Menu => "MainMenu",
            _ => "MainMenu",
        };

        Time.timeScale = 1;

        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;

        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}