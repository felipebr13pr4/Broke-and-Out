using UnityEngine;

public class BulletBrick : BricksMovement
{
    public void InitializeBullet(Sprite sprite, Transform parentTransform)
    {
        transform.parent = CreationsHolder.S_Transform.transform;
        transform.position = parentTransform.position;

        Vector2 size = new(1,0.5f);

        SpriteRenderer spriteRen = gameObject.AddComponent<SpriteRenderer>();
        spriteRen.color = Color.yellow;
        spriteRen.sprite = sprite;
        spriteRen.drawMode = SpriteDrawMode.Sliced;
        spriteRen.size = size;

        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = size;

        float time = 0.2f;
        float distance = 1;

        InitializeMovement(time, distance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player Hitbox")) return;
        PlayerBehavior player = collision.GetComponentInParent<PlayerBehavior>();
        if (player != null)
        player.TakeDamage(1);
        gameObject.SetActive(false);
    }
}
