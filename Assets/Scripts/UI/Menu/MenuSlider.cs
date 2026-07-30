using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MenuSlider : MonoBehaviour
{
    [SerializeField] private SliderType m_sliderType = SliderType.Volume;
    private Slider m_sliderComponent;
    public static event Action<SliderType, float> OnSliderChangedByType;

    private void Awake() => m_sliderComponent = GetComponent<Slider>();

    private void Start() => SliderInitialValue();

    private void OnEnable() => m_sliderComponent.onValueChanged.AddListener(SliderChanged);

    private void OnDisable() => m_sliderComponent.onValueChanged.RemoveListener(SliderChanged);

    private void SliderChanged(float value)
    {
        OnSliderChangedByType?.Invoke(m_sliderType, value);
    }

    private void SliderInitialValue()
    {
        m_sliderComponent.value = m_sliderType switch
        {
            SliderType.Volume => AudioController.Instance.P_AudioVolume,
            _ => 0,
        };
    }
}