using System;
using UnityEngine;

public class BrickBehavior : EntityBehavior
{
    protected BrickType m_brickType = BrickType.Basic;
    public static event Action<BrickType> OnDeath;
    protected override Color P_Color { get; set; } = new(0.2f, 1, 0.2f, 1);


    protected override void Die()
    {
        OnDeath?.Invoke(m_brickType);
        base.Die();
    }

    public virtual void Initialize(int health)
    {
        P_MaxHealth = health;
        InitializeColor();
    }
}