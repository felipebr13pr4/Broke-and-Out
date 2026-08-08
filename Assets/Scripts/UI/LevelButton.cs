using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] protected int m_assignedLevel;
    protected Button m_levelButton;
    public static event Action<int> OnLevelChanged;

    private void Awake()
    {
        m_levelButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        m_levelButton.onClick.AddListener(ChangeLevel);
    }

    private void OnDisable()
    {
        m_levelButton.onClick.RemoveListener(ChangeLevel);
    }

    protected virtual void ChangeLevel()
    {
        OnLevelChanged?.Invoke(m_assignedLevel);
        SceneController.Instance.ReloadScene();
    }

    public void Initialize(int level)
    {
        m_assignedLevel = level;
    }
}
