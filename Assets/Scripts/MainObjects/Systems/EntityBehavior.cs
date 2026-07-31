using System;
using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
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
            if (m_health <= 0) Die(); else SetColor(m_health);
        }
    }

    protected virtual void Start()
    {
        m_health = m_maxHealth;
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }

    protected void SetHealth(int healthValue) { m_health = healthValue; }

    protected virtual void SetColor(int health)
    {
        // TODO
    }
}
