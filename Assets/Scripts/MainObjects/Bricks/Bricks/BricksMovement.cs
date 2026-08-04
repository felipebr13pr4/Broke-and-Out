using System.Collections;
using UnityEngine;

public class BricksMovement : MonoBehaviour
{
    [SerializeField] private float m_timeToMove = 1;
    [SerializeField] private float m_distanceToMove = 1;

    private void OnEnable() => StartCoroutine(Move());

    public void InitializeMovement(float time, float distance)
    {
        m_timeToMove = time;
        m_distanceToMove = distance;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_timeToMove);
            transform.position += Vector3.down * m_distanceToMove;
            float sizeAdjustmentY = transform.localScale.y / 2;
            if (transform.position.y < ScreenBounds.Bottom - sizeAdjustmentY) gameObject.SetActive(false);
        }
    }
}
