using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallBehavior : MonoBehaviour
{
    [SerializeField] private Transform m_paddle;
    private Rigidbody2D m_rigidBody2d;
    private bool m_isRepositioning = false;
    
    private void Start() => m_rigidBody2d = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        float sizeAdjustment = transform.localScale.x / 2;

        if (!m_isRepositioning && m_rigidBody2d.position.y <= ScreenBounds.Bottom - sizeAdjustment)
            Reposition();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            EntityBehavior brick = collision.gameObject.GetComponent<EntityBehavior>();
            brick.TakeDamage(1);
        }
    }
    private void Reposition()
    {
        print("repositioning");
        m_isRepositioning = true;

        float dir = (m_paddle.position.x - m_rigidBody2d.position.x)/2;

        m_rigidBody2d.linearVelocityY = 1;
        m_rigidBody2d.linearVelocityX = dir;

        m_rigidBody2d.transform.position = new(transform.position.x, ScreenBounds.Top+3);
        m_isRepositioning = false;
    }
}