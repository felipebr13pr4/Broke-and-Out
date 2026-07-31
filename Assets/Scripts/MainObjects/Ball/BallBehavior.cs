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
            StartCoroutine(Reposition());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            EntityBehavior brick = collision.gameObject.GetComponent<EntityBehavior>();
            brick.TakeDamage(1);
        }
    }
    private IEnumerator Reposition()
    {
        print("repositioning");
        m_isRepositioning = true;
        for (int i = 0; i <= 25; i++)
        {
            m_rigidBody2d.linearVelocity = Vector2.zero;
            m_rigidBody2d.transform.position = new(m_paddle.transform.position.x,
                                                   m_paddle.transform.position.y+6);
            yield return new WaitForSeconds(0.01f);
        }
        m_isRepositioning = false;
    }
}