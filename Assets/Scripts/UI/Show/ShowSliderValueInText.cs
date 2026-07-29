using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowSliderValueInText : MonoBehaviour
{
    [SerializeField] private SliderType m_sliderType;
    private TextMeshProUGUI m_TextMeshPro;

    void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();

        float value = m_sliderType switch
        {
            SliderType.Volume => AudioController.Instance.P_AudioVolume,
            _ => 1f
        };

        ChangeText(m_sliderType, value);
    }
    
    private void OnEnable()
    {
        MenuSlider.OnSliderChangedByType += ChangeText;
    }

    private void OnDisable()
    {
        MenuSlider.OnSliderChangedByType -= ChangeText;
    }

    private void ChangeText(SliderType type, float value)
    {
        if (type != m_sliderType) return;
        string strLenght = m_sliderType switch
        {
            SliderType.Volume => "P0",
            _ => "F0"
        };
        m_TextMeshPro.text = value.ToString(strLenght);
    }
}