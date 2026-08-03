using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float m_bounceForce;

    private Rigidbody2D m_rigidBody2d;
    private Vector2 m_previousVelocity;

    private void Start() => m_rigidBody2d = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {

        float sizeAdjustment = transform.localScale.x / 2;

        m_rigidBody2d.position = new(
            Mathf.Clamp(m_rigidBody2d.transform.position.x, ScreenBounds.Left + sizeAdjustment,
                        ScreenBounds.Right - sizeAdjustment),
            Mathf.Clamp(m_rigidBody2d.transform.position.y, ScreenBounds.Bottom + sizeAdjustment - (sizeAdjustment * 2),
                        ScreenBounds.Top - sizeAdjustment - (sizeAdjustment * 2)));

        if (m_rigidBody2d.position.x >= ScreenBounds.Right - sizeAdjustment |
            m_rigidBody2d.position.x <= ScreenBounds.Left + sizeAdjustment) {
            Bounce(new(-m_rigidBody2d.linearVelocityX, m_rigidBody2d.linearVelocityY));
            m_previousVelocity = m_rigidBody2d.linearVelocity;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
            Vector2 dir = -(collision.rigidbody.position - m_rigidBody2d.position);
            dir.y += m_bounceForce;
            Bounce(dir);
            m_previousVelocity = m_rigidBody2d.linearVelocity;
        }
        if (collision.gameObject.CompareTag("Brick")) {
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 edge = contact.normal;
            
            if (Mathf.Abs(edge.x) > Mathf.Abs(edge.y))
                m_previousVelocity.x = edge.x > 0 ? 2.5f : -2.5f;

            print(m_previousVelocity + " prev velo");
            Vector2 dir = new(m_previousVelocity.x,
                -(collision.transform.position.y - m_rigidBody2d.transform.position.y) * (m_bounceForce/5));
            Bounce(dir);
        }
    }

    private void Bounce(Vector2 dir)
    {
        m_rigidBody2d.linearVelocity = dir;
    }
}