using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MenuCheckmark : MonoBehaviour
{
    [SerializeField] private CheckmarkType m_checkmarkType;
    private Toggle m_toggleComponent;
    public static event Action<CheckmarkType, bool> OnCheckmark;

    private void Awake() => m_toggleComponent = GetComponent<Toggle>();

    private void Start() => InitialState();

    private void OnEnable() => m_toggleComponent.onValueChanged.AddListener(CheckmarkClicked);
    
    private void OnDisable() => m_toggleComponent.onValueChanged.RemoveListener(CheckmarkClicked);
    
    private void CheckmarkClicked(bool state)
    {
        OnCheckmark?.Invoke(m_checkmarkType, state);
    }

    private void InitialState()
    {
        switch (m_checkmarkType)
        {
            case CheckmarkType.Fullscreen:
                m_toggleComponent.isOn = Screen.fullScreenMode == FullScreenMode.FullScreenWindow;
                return;
        }
    }
}