using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class MenuDropdown : MonoBehaviour
{
    [SerializeField] private DropdownType m_dropdownType;
    private TMP_Dropdown m_dropdownComponent;
    public static event Action<DropdownType, int, string> OnDropdown;

    private void Awake() => m_dropdownComponent = GetComponent<TMP_Dropdown>();

    private void Start() => InitialState();

    private void OnEnable() => m_dropdownComponent.onValueChanged.AddListener(DropdownChanged);

    private void OnDisable() => m_dropdownComponent.onValueChanged.RemoveListener(DropdownChanged);

    private void DropdownChanged(int index)
    {
        string optionName = m_dropdownComponent.options[index].text;
        OnDropdown?.Invoke(m_dropdownType, index, optionName);
    }


    private void InitialState()
    {
        switch (m_dropdownType)
        {
            case DropdownType.ScreenRes:
                m_dropdownComponent.value = HandleScreenResDropdown();
                return;
        }
    }

    private int HandleScreenResDropdown()
    {
        int index = 0;
        for (int i = 0; i < m_dropdownComponent.options.Count; i++)
        {
            string optionName = m_dropdownComponent.options[i].text;
            string[] optionSize = m_dropdownComponent.options[i].text.Split("x");
            if (int.Parse(optionSize[0]) == Screen.width &&
                int.Parse(optionSize[1]) == Screen.height)
            {
                index = i;
            }
        }
        return index;
    }
}