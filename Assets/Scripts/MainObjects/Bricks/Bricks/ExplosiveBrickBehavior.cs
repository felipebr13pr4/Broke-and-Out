using UnityEngine;

public class ExplosiveBrickBehavior : BrickBehavior
{
    [SerializeField] private int m_explosionRange;

    public void Initialize(int health, int explosionRange)
    {
        m_explosionRange = explosionRange;
        P_Health = health;
        SetHealth(health);
    }

    protected override void Die()
    {
        // TODO
        base.Die();
    }
}