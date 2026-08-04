using UnityEngine;

public class PlayerBehavior : EntityBehavior
{
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
            print(P_Health);
        }
    }


    protected override void Die()
    {
        // TODO
        base.Die();
    }
}
