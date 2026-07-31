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

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBehavior player = collision.gameObject.GetComponent<PlayerBehavior>();

            int healthBeforeAttack = P_Health;
            int playerHealthBeforeAttack = player.P_Health;

            player.P_Health -= healthBeforeAttack;
            P_Health -= playerHealthBeforeAttack;
        }
    }

    protected override void Die()
    {
        OnDeath?.Invoke(m_brickType);
        base.Die();
    }

    public void Initialize(int health)
    {
        P_Health = health;
        SetHealth(health);
    }
}