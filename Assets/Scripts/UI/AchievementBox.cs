using TMPro;
using UnityEngine;

public class AchievementBox : MonoBehaviour
{
    [SerializeField] public string m_name;
    [SerializeField] private AchievementType m_type;
    [SerializeField] private int m_reqAmount;
    [SerializeField] TextMeshProUGUI m_nameText;
    [SerializeField] TextMeshProUGUI m_numberText;
    [SerializeField] GameObject m_transparencyWindow;
    private bool m_hasAchieved;

    private void OnEnable()
    {
        if (m_hasAchieved) return;
        m_hasAchieved = HasAchievedGoal(m_type, m_reqAmount);

        if (m_hasAchieved) m_transparencyWindow.SetActive(false);

        int amount = CheckWhichAmountByType(m_type);

        m_nameText.text = m_name;
        m_numberText.text = m_hasAchieved ?
                            m_reqAmount.ToString() + " / " + m_reqAmount.ToString() :
                            amount.ToString() + " / " + m_reqAmount.ToString();
    }

    private bool HasAchievedGoal(AchievementType type, int reqAmount)
    {
        int amount = CheckWhichAmountByType(type);
        return amount >= reqAmount;
    }

    private int CheckWhichAmountByType(AchievementType type)
    {
        int amount = type switch
        {
            AchievementType.BrickBroken => DataController.Instance.P_BrickBroken,
            AchievementType.TimesKilled => DataController.Instance.P_TimesKilled,
            AchievementType.DamageTaken => DataController.Instance.P_DamageTaken,
            AchievementType.DamageDealt => DataController.Instance.P_DamageDealt,
            AchievementType.BasicBricksBroken => DataController.Instance.P_BasicBricksBroken,
            AchievementType.RangedBricksBroken => DataController.Instance.P_RangedBricksBroken,
            AchievementType.ExplosiveBricksBroken => DataController.Instance.P_ExplosiveBricksBroken,
            _ => 0,
        };
        return amount;
    }

    public void Initialize(string name, AchievementType type, int reqAmount)
    {
        m_name = name;
        m_type = type;
        m_reqAmount = reqAmount;
    }

    [ContextMenu("Set Contents.")]
    private void SetContents()
    {
        m_nameText.text = m_name;
        m_numberText.text = m_reqAmount.ToString() + " / " + m_reqAmount.ToString();
    }
}