using UnityEngine;

public class ExplosiveBrickBehavior : BrickBehavior
{
    [SerializeField] private int m_explosionRange;

    public void Initialize(int explosionRange)
    {
        m_explosionRange = explosionRange;
        InitializeColor(1, 0.2f, 0.2f);
    }

    protected override void Die()
    {
        // TODO
        base.Die();
    }
}