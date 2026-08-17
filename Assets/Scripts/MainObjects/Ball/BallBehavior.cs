using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallBehavior : MonoBehaviour
{
    [SerializeField] private Transform m_paddle;
    [SerializeField] private RepositionArea m_repositioningArea;
    private Rigidbody2D m_rigidBody2d;
    private bool m_isRepositioning = false;
    public static event Action<Vector2> OnBallReposition;
    

    
    private void Start() => m_rigidBody2d = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        float sizeAdjustmentY = transform.localScale.y / 2;

        if (!m_isRepositioning && m_rigidBody2d.position.y <= ScreenBounds.Bottom - sizeAdjustmentY)
            StartCoroutine(PlayerReposition());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            EntityBehavior brick = collision.gameObject.GetComponent<EntityBehavior>();
            brick.TakeDamage(1);
        }
    }

    private IEnumerator PlayerReposition()
    {
        m_isRepositioning = true;

        GetComponent<AudioHolder>().ActivateSound(0);


        if (m_repositioningArea.P_IsBrickinside) { VoidRepositioning(); yield break; }
        
        for (int i = 0; i <= 25; i++)
        {
            m_rigidBody2d.linearVelocity = Vector2.zero;
            m_rigidBody2d.transform.position = new(m_paddle.transform.position.x, -10);

            yield return new WaitForSeconds(0.01f);
        }

        OnBallReposition?.Invoke(m_rigidBody2d.linearVelocity);
        m_isRepositioning = false;
    }

    private void VoidRepositioning()
    {
        float dir = (m_paddle.position.x - m_rigidBody2d.position.x) / 2;

        m_rigidBody2d.linearVelocityY = 1;
        m_rigidBody2d.linearVelocityX = dir;

        m_rigidBody2d.transform.position = new(transform.position.x, ScreenBounds.Top + 1);

        OnBallReposition?.Invoke(m_rigidBody2d.linearVelocity);
        m_isRepositioning = false;
    }
}