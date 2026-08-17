using System.Collections;
using UnityEngine;

public class GameScreenController : MonoBehaviour
{
    public static GameScreenController Instance { get; private set; }
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

    private void Start()
    {
        bool fullScreen = PlayerPrefs.GetInt(PrefKeys.FullScreen, 1) != 0;
        FullScreen(fullScreen);
        int width = PlayerPrefs.GetInt(PrefKeys.ScreenWidth, 1920);
        int height = PlayerPrefs.GetInt(PrefKeys.ScreenHeight, 1080);
        StartCoroutine(ChangeScreenResolution(width, height));
    }

    public void FullScreen(bool state)
    {
        Screen.fullScreenMode = state ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public IEnumerator ChangeScreenResolution(int x, int y)
    {
        yield return null;
        Screen.SetResolution(x, y, Screen.fullScreenMode);
    }
}