using UnityEngine;

public class PlayerBehavior : EntityBehavior
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            TakeDamage(hitter: collision);
        }
    }

    protected override void Die()
    {
        // TODO
        base.Die();
    }
}
