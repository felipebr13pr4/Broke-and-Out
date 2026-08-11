using System;
using UnityEngine;

public class PlayerBehavior : EntityBehavior
{
    public static event Action OnDeath;

    private void Start()
    {
        P_MaxHealth = 5;
        InitializeColor(reverse: true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            TakeDamage(hitter: collision.gameObject.GetComponent<EntityBehavior>(),
                       takeAndDeal: true);
        }
    }

    public override void TakeDamage(int damage = 0, EntityBehavior hitter = null, bool takeAndDeal = false)
    {
        GetComponent<AudioHolder>().ActivateSound(0);
        base.TakeDamage(damage, hitter, takeAndDeal);
    }

    protected override void Die()
    {
        OnDeath?.Invoke();
        base.Die();
    }
}
