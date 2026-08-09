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

    protected override void Die()
    {
        // TODO
        OnDeath?.Invoke();
        base.Die();
    }
}
