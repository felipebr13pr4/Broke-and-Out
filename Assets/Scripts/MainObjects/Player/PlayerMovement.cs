using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float m_speed = 2;
    protected Rigidbody2D m_rigidBody2d;
    private float m_moveDir;
    private SpriteRenderer m_spriteRenderer;

    private void Start() { m_rigidBody2d = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>(); }


    private void Update()
    {
        m_moveDir = Keyboard.current.dKey.isPressed ? 1 :
                    Keyboard.current.aKey.isPressed ? -1 : 0;
    }

    private void FixedUpdate()
    {
        m_rigidBody2d.linearVelocity = new Vector2(m_moveDir * m_speed, 0);

        Vector3 pos = m_rigidBody2d.transform.position;
        float sizeAdjustmentX = m_spriteRenderer.size.x / 2;
        pos.x = Mathf.Clamp(pos.x, ScreenBounds.Left + sizeAdjustmentX,
                            ScreenBounds.Right - sizeAdjustmentX);
        m_rigidBody2d.position = pos;
    }
}
