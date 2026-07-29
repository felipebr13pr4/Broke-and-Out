using UnityEngine;

public class CheckmarkController : MonoBehaviour
{
    public static CheckmarkController Instance { get; private set; }
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
        MenuCheckmark.OnCheckmark += ExecuteAction;
    }

    private void OnDisable()
    {
        MenuCheckmark.OnCheckmark -= ExecuteAction;
    }

    private void ExecuteAction(CheckmarkType type, bool state)
    {
        switch (type)
        {
            case CheckmarkType.Fullscreen:
                GameScreenController.Instance.FullScreen(state);
                return;
        }
    }
}