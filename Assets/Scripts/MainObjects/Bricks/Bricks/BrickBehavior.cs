using System;
using UnityEngine;

public class BrickBehavior : EntityBehavior
{
    protected BrickType m_brickType = BrickType.Basic;
    public static event Action<BrickType> OnDeath;

    protected override void Start()
    {
        base.Start();
    }

    /*protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(hitter: collision);
        }
    }*/

    protected override void Die()
    {
        OnDeath?.Invoke(m_brickType);
        base.Die();
    }

    public void Initialize()
    {
        InitializeColor(0.2f, 1, 0.2f);
    }
}