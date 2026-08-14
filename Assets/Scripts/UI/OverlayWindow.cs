using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_windowTitle;
    [SerializeField] private GameObject m_components;
    [SerializeField] private GameObject[] m_otherWindows;

    private void OnEnable()
    {
        LevelController.OnLevelClear += OpenOverlayWindow;
        PlayerBehavior.OnDeath += OpenOverlayWindow;
        GameStateController.OnGamePaused += OpenOverlayWindow;
    }

    private void OnDisable()
    {
        LevelController.OnLevelClear -= OpenOverlayWindow;
        PlayerBehavior.OnDeath -= OpenOverlayWindow;
        GameStateController.OnGamePaused -= OpenOverlayWindow;
    }

    private void OpenOverlayWindow()
    {
        print("reached openoverlay");
        bool isPaused = Time.timeScale < 1;
        m_components.SetActive(isPaused);
        StartCoroutine(UpdateTitle()); 
        StartCoroutine(EnsureComponentsActivation());
        if (!isPaused)
        {
            foreach (var window in m_otherWindows) window.SetActive(false);
            gameObject.SetActive(true);
        }
    }

    private IEnumerator EnsureComponentsActivation()
    {
        for (int i = 0; i < 10; i++)
        {
            bool isPaused = Time.timeScale < 1;
            m_components.SetActive(isPaused);
            yield return null;
        }
    }

    private IEnumerator UpdateTitle()
    {
        while (true)
        {
            while (!m_windowTitle.gameObject.activeInHierarchy) yield return null;
            m_windowTitle.text = HandleTitle();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    private string HandleTitle()
    {
        if (GameStateController.Instance.P_IsPlayerDead)
        {
            return "You Have Died!";
        }
        else if (GameStateController.Instance.P_IsLevelClear & 
            LevelController.Instance.P_IsRandomMode)
        {
            return "Random Level Complete!";
        }
        else if (GameStateController.Instance.P_IsLevelClear)
        {
            return $"Level {LevelController.Instance.P_CurrentLevel + 1} complete!";
        }
        else if (Time.timeScale == 0)
        {
            return "Game Paused.";
        }else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            return "Broke And Out";
        }
        return "";
    }
}
