using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndscreenWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_windowTitle;
    [SerializeField] private GameObject[] m_returnButtons;
    [SerializeField] private GameObject m_pauseButton;
    [SerializeField] private GameObject m_components;
    [SerializeField] private Image m_image;

    private void OnEnable()
    {
        BrickRowBehavior.OnRowClear += RowCleared;
        PlayerBehavior.OnDeath += PlayerDies;
    }

    private void OnDisable()
    {
        BrickRowBehavior.OnRowClear -= RowCleared;
        PlayerBehavior.OnDeath -= PlayerDies;
    }

    private void RowCleared() => StartCoroutine(CheckIfAllCleared());

    private IEnumerator CheckIfAllCleared()
    {
        yield return null;
        yield return null;
        if (LevelController.Instance.P_RowsCleared == 5 & LevelController.Instance.P_IsRandomMode)
        {
            OpenEndscreen("Random Level complete!");
            yield break;
        }
        if (LevelController.Instance.P_RowsCleared == 5)
        {
            OpenEndscreen($"Level {LevelController.Instance.P_CurrentLevel + 1} complete!");
        }
    }

    private void PlayerDies() =>StartCoroutine(DelayEndScreen("You have died!"));

    private IEnumerator DelayEndScreen(string title)
    {
        yield return null;
        yield return null;
        yield return null;
        OpenEndscreen(title);
    }

    private void OpenEndscreen(string title)
    {
        m_image.enabled = true;
        m_components.SetActive(true);
        m_pauseButton.SetActive(false);
        m_windowTitle.text = title;
        Time.timeScale = 0;
        for (int i = 0; i < m_returnButtons.Length; i++) 
        {
            if (i <= 2) m_returnButtons[i].SetActive(false);
            if (i > 2) m_returnButtons[i].SetActive(true);
        }
    }
}
