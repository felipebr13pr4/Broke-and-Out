using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioHolder))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private RectTransform m_pauseWindow;
    private Button m_pauseButton;

    private void Awake()
    {
        m_pauseButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        m_pauseButton.onClick.AddListener(TogglePause);
        LevelController.OnLevelClear += UnableToPause;
        PlayerBehavior.OnDeath += UnableToPause;

    }

    private void OnDisable()
    {
        m_pauseButton.onClick.RemoveListener(TogglePause);
        LevelController.OnLevelClear -= UnableToPause;
        PlayerBehavior.OnDeath -= UnableToPause;

    }

    private void UnableToPause() => gameObject.SetActive(false);

    private void TogglePause()
    {
        GameStateController.Instance.TogglePause();
    }
}