using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    [SerializeField] private ButtonType m_buttonType;
    private Button m_buttonComponent;
    public static event Action<ButtonType> OnButtonTypeClicked;

    private void Awake() => m_buttonComponent = GetComponent<Button>();

    private void OnEnable() => m_buttonComponent.onClick.AddListener(ButtonClicked);

    private void OnDisable() => m_buttonComponent.onClick.RemoveListener(ButtonClicked);
    private void ButtonClicked()
    {
        OnButtonTypeClicked?.Invoke(m_buttonType);
    }
}