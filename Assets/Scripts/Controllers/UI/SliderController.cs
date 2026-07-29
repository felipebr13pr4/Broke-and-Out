using UnityEngine;

public class SliderController : MonoBehaviour
{
    public static SliderController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        MenuSlider.OnSliderChangedByType += ExecuteAction;
    }

    private void OnDisable()
    {
        MenuSlider.OnSliderChangedByType -= ExecuteAction;
    }

    private void ExecuteAction(SliderType type, float value)
    {
        switch (type)
        {
            case SliderType.Volume:
                AudioController.Instance.SetAudio(value);
                return;
        }
    }
}