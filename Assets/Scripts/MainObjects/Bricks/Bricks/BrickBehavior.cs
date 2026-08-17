using System;
using UnityEngine;

public class BrickBehavior : EntityBehavior
{
    protected virtual BrickType P_BrickType { get; set; } = BrickType.Basic;
    public static event Action<BrickType> OnDeath;
    protected override Color P_Color { get; set; } = new(0.2f, 1, 0.2f, 1);

    public override void TakeDamage(int damage = 0, EntityBehavior hitter = null, bool takeAndDeal = false)
    {
        GetComponent<AudioHolder>().ActivateStoppableSound(0);
        base.TakeDamage(damage, hitter, takeAndDeal);
    }

    protected override void Die()
    {
        OnDeath?.Invoke(P_BrickType);
        base.Die();
    }

    public virtual void Initialize(int health)
    {
        P_MaxHealth = health;
        InitializeColor();
    }
}