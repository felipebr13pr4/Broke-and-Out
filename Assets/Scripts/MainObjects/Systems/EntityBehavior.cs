using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    [SerializeField] protected Color m_color = Color.white;
    [SerializeField] private int m_maxHealth = 3;
    public int MaxHealth => m_maxHealth;
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
            if (m_health <= 0) Die(); else LightenColor();
        }
    }
    private SpriteRenderer m_sprite;
    protected float[] m_colorsValues;

    protected virtual void Start()
    {
        m_health = m_maxHealth;
        m_sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void TakeDamage(int damage = 0, EntityBehavior hitter = null, bool takeAndDeal = false)
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

    public void InitializeHealth(int healthValue)
    { m_health = healthValue; m_maxHealth = healthValue; }

    protected virtual void InitializeColor(float red, float green, float blue)
    {
        m_sprite = GetComponentInChildren<SpriteRenderer>();

        m_colorsValues = new float[3];
        m_colorsValues[0] = red; m_colorsValues[1] = green; m_colorsValues[2] = blue;

        m_color = new Color(m_colorsValues[0], m_colorsValues[1], m_colorsValues[2], 1);
        m_sprite.color = m_color;

        DarkenColor();
    }

    protected virtual void DarkenColor()
    {
        float darken = 1f - (0.15f * P_Health);
        m_sprite.color *= darken;
        m_sprite.color = new(m_sprite.color.r, m_sprite.color.g, m_sprite.color.b, a: 1f);
    }

    protected virtual void LightenColor()
    {
        float lighten = 1f + (0.15f * P_Health);
        m_sprite.color *= lighten;
        m_sprite.color = new(m_sprite.color.r, m_sprite.color.g, m_sprite.color.b, a: 1f);
    }
}
