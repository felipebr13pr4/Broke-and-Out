using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;
    private float m_vanishTime;
    private GameObject m_explosion;

    private void OnEnable() => StartCoroutine(Vanish()); 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.activeInHierarchy) return;
        if (collision.gameObject.CompareTag("Player Hitbox") | collision.gameObject.CompareTag("Brick"))
        {
            EntityBehavior target = collision.gameObject.GetComponent<EntityBehavior>();
            if (collision.gameObject.CompareTag("Player Hitbox"))
                target = collision.gameObject.GetComponentInParent<EntityBehavior>();
            target.TakeDamage(1);
        }
    }

    private IEnumerator Vanish()
    {
        float j = 0.1f;
        for (int i = 0; i < 10; i++) 
        {
            m_spriteRenderer.color -= new Color(0,0,0, j);
            yield return new WaitForSeconds(m_vanishTime);
        }
        gameObject.SetActive(false);
    }

    public void Initialize(int damage, Vector2 size, Transform parentTransform, Sprite sprite, Color color, float vanishTime) 
    {
        name = "Explosion " + damage;

        transform.parent = CreationsHolder.S_Transform.transform;
        transform.position = parentTransform.position;

        BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        box.size = size;

        m_spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = sprite;
        m_spriteRenderer.color = color;
        m_spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        m_spriteRenderer.size = size;

        Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        rigidbody2D.gravityScale = 0;

        m_vanishTime = vanishTime;

        gameObject.SetActive(true);

        if (damage > 1)
        {
            Explosion explosion = m_explosion.GetComponentInChildren<Explosion>();
            explosion.Initialize(damage-1, size*0.8f, transform, sprite, color, vanishTime*4f);
            explosion.transform.parent = transform;
        }
    }

    public void InitializeChildren(int damage)
    {
        if (damage > 1)
        {
            m_explosion = new GameObject("Explosion");
            m_explosion.SetActive(false);
            Explosion explosion = m_explosion.AddComponent<Explosion>();
            explosion.InitializeChildren(damage - 1);
            explosion.transform.parent = transform;
        }
    }
}
