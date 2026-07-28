using System.Collections;
using UnityEngine;

public class BricksMovement : MonoBehaviour
{
    [SerializeField] private float m_timeToMove = 1;
    [SerializeField] private float m_distanceToMove = 1;

    private void Start() => StartCoroutine(Move());

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_timeToMove);
            transform.position += Vector3.down * m_distanceToMove;
        }
    }
}
