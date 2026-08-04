using UnityEngine;

public class BulletBrick : BricksMovement
{
    public void InitializeBullet(Sprite sprite, Transform parentTransform)
    {
        transform.parent = BulletsHolder.S_Transform.transform;
        transform.position = parentTransform.position;

        SpriteRenderer spriteRen = gameObject.AddComponent<SpriteRenderer>();
        spriteRen.color = Color.yellow;
        spriteRen.sprite = sprite;

        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new(1,1);

        float time = 0.2f;
        float distance = 1;

        InitializeMovement(time, distance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        PlayerBehavior player = collision.GetComponent<PlayerBehavior>();
        player.TakeDamage(1);
        gameObject.SetActive(false);
    }
}
