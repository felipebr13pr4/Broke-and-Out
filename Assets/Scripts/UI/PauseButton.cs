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
    }

    private void OnDisable()
    {
        m_pauseButton.onClick.RemoveListener(TogglePause);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame & isActiveAndEnabled) TogglePause();
    }

    public void TogglePause()
    {
        GetComponent<AudioHolder>().ActivateSound(0);
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
        bool shouldOpenPauseWindow = Time.timeScale < 1;
        m_pauseWindow.gameObject.SetActive(shouldOpenPauseWindow);
    }
}