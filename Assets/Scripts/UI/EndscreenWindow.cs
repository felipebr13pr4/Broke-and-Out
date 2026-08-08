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
        BrickBehavior.OnDeath += BrickDies;
        PlayerBehavior.OnDeath += PlayerDies;
    }

    private void OnDisable()
    {
        BrickBehavior.OnDeath -= BrickDies;
        PlayerBehavior.OnDeath -= PlayerDies;
    }

    private void BrickDies(BrickType type)
    {
        StartCoroutine(CheckIfCleared());
    }

    private IEnumerator CheckIfCleared()
    {
        yield return null;
        yield return null;
        if (LevelController.Instance.P_RowsCleared == 5)
        {
            OpenEndscreen($"Level {DataController.Instance.P_CurrentLevel + 1} complete!");
        }
    }

    private void PlayerDies() =>
        OpenEndscreen("You have died!");

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
