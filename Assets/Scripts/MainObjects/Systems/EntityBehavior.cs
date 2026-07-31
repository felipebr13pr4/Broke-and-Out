using System;
using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    [SerializeField] protected Color m_color = Color.white;
    [SerializeField] private int m_maxHealth = 3;
    public int MaxHealth => m_maxHealth;
    private int m_health;
    public int P_Health
    {
        get { return m_health; }
        set
        {
            m_health = value;
            m_health = Mathf.Clamp(m_health, 0, m_maxHealth);
            if (m_health <= 0) Die(); else DarkenColor();
        }
    }
    private SpriteRenderer m_sprite;
    protected float[] m_colorsValues;

    protected virtual void Start()
    {
        m_health = m_maxHealth;
    }

    public virtual void TakeDamage(int damage = 0, Collision2D hitter = null)
    {
        if (hitter != null)
        {
            EntityBehavior entity = hitter.gameObject.GetComponent<EntityBehavior>();

            P_Health -= entity.P_Health;
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
        float darken = HandleDarkening();
        m_sprite.color *= darken;
        m_sprite.color = new(m_sprite.color.r, m_sprite.color.g, m_sprite.color.b, a: 1f);
    }

    private float HandleDarkening()
    {
        float darken = P_Health switch
        {
            3 => 0.9f,
            2 => 0.7f,
            1 => 0.5f,
            _ => 1
        };
        return darken;
    }
}
