using UnityEngine;

public class ExplosiveBrickBehavior : BrickBehavior
{
    [SerializeField] private int m_explosionRange;
    public int P_ExplosionRange { get => m_explosionRange; set { m_explosionRange = value; } }
    protected override Color P_Color { get; set; } = new(1, 0.2f, 0.2f, 1);

    public override void Initialize(int health)
    {
        base.Initialize(health);
    }

    protected override void Die()
    {
        // TODO
        base.Die();
    }
}