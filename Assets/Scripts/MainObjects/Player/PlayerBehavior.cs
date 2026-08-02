using UnityEngine;
using UnityEngine.Rendering;

public class PlayerBehavior : EntityBehavior
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            TakeDamage(hitter: collision.gameObject.GetComponent<EntityBehavior>(),
                       takeAndDeal: true);
            print(P_Health);
        }
    }

    protected override void Die()
    {
        // TODO
        base.Die();
    }
}
