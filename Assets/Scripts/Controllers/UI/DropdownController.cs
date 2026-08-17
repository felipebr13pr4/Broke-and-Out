using UnityEngine;

public class DropdownController : MonoBehaviour
{
    public static DropdownController Instance { get; private set; }
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
        MenuDropdown.OnDropdown += ExecuteAction;
    }

    private void OnDisable()
    {
        MenuDropdown.OnDropdown -= ExecuteAction;
    }

    private void ExecuteAction(DropdownType type, int index, string optionName)
    {
        switch (type)
        {
            case DropdownType.ScreenRes:
                HandleScreenResDropdown screenRes = new(optionName);
                StartCoroutine(GameScreenController.Instance.
                    ChangeScreenResolution(screenRes.width, screenRes.height));
                return;
        }
    }

    private struct HandleScreenResDropdown
    {
        public int width;
        public int height;
        public HandleScreenResDropdown(string optionName)
        {
            string[] optionSize = optionName.Split("x");

            width = int.Parse(optionSize[0]);
            height = int.Parse(optionSize[1]);
        }
    }
}