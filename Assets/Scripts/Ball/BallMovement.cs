using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float m_bounceForce;

    private Collider2D m_collider2d;
    private Rigidbody2D m_rigidBody2d;
    private Vector2 m_previousVelocity;

    private void Start()
    {
        m_collider2d = GetComponent<Collider2D>();
        m_rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_previousVelocity = m_rigidBody2d.linearVelocity;

        float sizeAdjustment = transform.localScale.x / 2;


        m_rigidBody2d.position = new(
            Mathf.Clamp(m_rigidBody2d.transform.position.x, ScreenBounds.Left + sizeAdjustment,
                        ScreenBounds.Right - sizeAdjustment),
            Mathf.Clamp(m_rigidBody2d.transform.position.y, ScreenBounds.Bottom + sizeAdjustment - (sizeAdjustment * 2),
                        ScreenBounds.Top - sizeAdjustment));

        if (m_rigidBody2d.position.x >= ScreenBounds.Right - sizeAdjustment |
            m_rigidBody2d.position.x <= ScreenBounds.Left + sizeAdjustment) {
            Bounce(new(-m_rigidBody2d.linearVelocityX, m_rigidBody2d.linearVelocityY)); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
            Vector2 dir = -(collision.rigidbody.position - m_rigidBody2d.position);
            dir.y *= m_bounceForce;
            Bounce(dir);
        }
        if (collision.gameObject.CompareTag("Brick")) {
            Vector2 dir = new(m_previousVelocity.x,
                -(collision.transform.position.y - m_rigidBody2d.transform.position.y) * (m_bounceForce/4));
            Bounce(dir); collision.gameObject.SetActive(false);
        }
    }

    private void Bounce(Vector2 dir)
    {
        m_rigidBody2d.linearVelocity = dir;
    }
}
