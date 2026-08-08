using TMPro;
using UnityEngine;

public class LevelButtonsCreator : MonoBehaviour
{
    [SerializeField] private GameObject m_levelButtonPrefab;
    [SerializeField] private int m_amount;

    [ContextMenu("Spawn Level Buttons")]
    private void SpawnButtons()
    {
        for (int i = 0; i < m_amount; i++)
        {
            GameObject prefab = Instantiate(m_levelButtonPrefab, transform);
            LevelButton levelButton = prefab.GetComponent<LevelButton>();
            levelButton.Initialize(i);
            prefab.name = $"Level {i+1} Button";

            TextMeshProUGUI textMeshPro = prefab.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = (i+1).ToString();
        }
    }

    [ContextMenu("Clear Level Buttons")]
    private void ClearButtons()
    {
        LevelButton[] buttons = GetComponentsInChildren<LevelButton>();
        foreach (LevelButton button in buttons)
        {
            DestroyImmediate(button.gameObject);
        }
    }
}
