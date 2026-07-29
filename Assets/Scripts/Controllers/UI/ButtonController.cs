using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public static ButtonController Instance { get; private set; }
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
        MenuButton.OnButtonTypeClicked += ExecuteAction;
    }

    private void OnDisable()
    {
        MenuButton.OnButtonTypeClicked -= ExecuteAction;
    }

    private void ExecuteAction(ButtonType type)
    {
        switch (type)
        {
            case ButtonType.Start:
                SceneController.Instance.LoadScene(SceneType.Game);
                return;

            case ButtonType.Retry:
                SceneController.Instance.ReloadScene();
                return;

            case ButtonType.MainMenu:
                SceneController.Instance.LoadScene(SceneType.Menu);
                return;

            case ButtonType.Quit:
                SavingController.Instance.SaveAll();
                Application.Quit();
                return;

            case ButtonType.SaveSettings:
                SavingController.Instance.SaveAll();
                return;
        }
    }
}