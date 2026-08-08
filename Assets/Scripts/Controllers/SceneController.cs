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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetThings;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetThings;
    }

    public void LoadScene(SceneType type)
    {
        string sceneToLoad = type switch
        {
            SceneType.Game => "MainGame",
            SceneType.Menu => "MainMenu",
            _ => "MainMenu",
        };

        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void ResetThings(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
        LevelController.Instance.P_RowsCleared = 0;
    }
}