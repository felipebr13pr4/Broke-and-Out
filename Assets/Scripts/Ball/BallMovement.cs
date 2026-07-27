using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float m_bounceForce;

    private Collider2D m_collider2d;
    private Rigidbody2D m_rigidBody2d;
    
    private void Start()
    {
        m_collider2d = GetComponent<Collider2D>();
        m_rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float sizeAdjustment = transform.localScale.x / 2;

        m_rigidBody2d.position = new(
            Mathf.Clamp(m_rigidBody2d.transform.position.x, ScreenBounds.Left + sizeAdjustment,
                        ScreenBounds.Right - sizeAdjustment),
            Mathf.Clamp(m_rigidBody2d.transform.position.y, ScreenBounds.Bottom + sizeAdjustment - (sizeAdjustment * 2),
                        ScreenBounds.Top - sizeAdjustment));

        if (m_rigidBody2d.position.x >= ScreenBounds.Right - sizeAdjustment |
            m_rigidBody2d.position.x <= ScreenBounds.Left + sizeAdjustment) BounceSide();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Bounce(collision);
    }

    private void BounceSide()
    {
        m_rigidBody2d.linearVelocity = new(-m_rigidBody2d.linearVelocityX, m_rigidBody2d.linearVelocityY);
    }

    private void Bounce(Collision2D collision)
    {
        Vector3 pos = collision.gameObject.transform.position - transform.position;
        
        Vector2 dir = new(pos.x = -pos.x, Mathf.Abs(pos.y)* m_bounceForce);
        print(dir);
        m_rigidBody2d.linearVelocity = dir;
    }
}
