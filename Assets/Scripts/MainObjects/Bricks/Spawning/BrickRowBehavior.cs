using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class BrickRowBehavior : MonoBehaviour
{
    [SerializeField] private BricksMovement[] m_bricks = new BricksMovement[11];
    private RowData m_rowData;
    public RowData P_RowData { get => m_rowData; set => m_rowData = value; }
    private bool m_isLocked = true;
    public bool P_IsLocked { get => m_isLocked; set => m_isLocked = value; }

    private void Awake() => m_bricks = GetComponentsInChildren<BricksMovement>();

    private void Start()
    {
        StartCoroutine(HandleBricks());
    }

    private IEnumerator HandleBricks()
    {
        while (m_isLocked)
        {
            yield return null;
        }
        print("test 2");
        yield return null;
        for (int i = 0; i < m_bricks.Length; i++)
        {
            m_bricks[i].gameObject.SetActive(m_rowData.P_ShouldBrickActive[i]);
            m_bricks[i].SetMovement(m_rowData.P_BrickData[i].P_timeToMove,
                                  m_rowData.P_BrickData[i].P_distanceToMove);
        }
    }
}