using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private int m_health = 3;
    public int P_Health {
        get { return m_health; }
        set { 
            m_health = value;
            if (m_health <= 0) Die();
            m_health = Mathf.Clamp(m_health, 0, 3);
        } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            P_Health -= 1;
        }
    }

    private void Die()
    {
        // TODO
    }
}
