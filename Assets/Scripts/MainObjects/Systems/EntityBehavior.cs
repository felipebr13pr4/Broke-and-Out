using UnityEngine;
using UnityEngine.Timeline;

public class EntityBehavior : MonoBehaviour
{
    [SerializeField] protected int m_maxHealth = 3;
    protected virtual int P_MaxHealth { get => m_maxHealth; set { m_maxHealth = value; m_health = value; } }
    private int m_lastHealt;
    private int m_health;
    public int P_Health
    {
        get { return m_health; }
        set
        {
            m_lastHealt = m_health;
            m_health = value;
            m_health = Mathf.Clamp(m_health, 0, m_maxHealth);
            if (m_health <= 0) Die(); else ChangeColor();
        }
    }
    private SpriteRenderer m_sprite;
    public SpriteRenderer P_Sprite => m_sprite;
    protected ColorStatesData m_colorData;
    protected virtual Color P_Color { get; set; } = Color.white;
    protected bool isReverseBrightening;

    public void TakeDamage(int damage = 0, EntityBehavior hitter = null, bool takeAndDeal = false)
    {
        if (hitter != null)
        {
            P_Health -= hitter.P_Health;
            if (takeAndDeal) hitter.TakeDamage(m_lastHealt);
            return;
        }
        P_Health -= damage;
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }

    protected void InitializeColor(float darken = 0.15f, bool reverse = false)
    {
        m_sprite = GetComponentInChildren<SpriteRenderer>();

        m_colorData = new(P_Color, P_Health, darken);
        isReverseBrightening = reverse;
        ChangeColor();
    }

    protected void ChangeColor()
    {
        int index = 0;
        if (isReverseBrightening) index = m_colorData.P_ColorsStates.Length - P_Health;
        else index = P_Health-1;
        print("iiindex: " + index);
        m_sprite.color = m_colorData.P_ColorsStates[index];
    }
}