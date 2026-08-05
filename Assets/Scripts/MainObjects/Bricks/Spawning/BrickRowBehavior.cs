using System.Collections;
using Unity.VisualScripting;
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
            BrickType type = m_rowData.P_BrickData[i].P_BrickType;

            bool isSpecial = type != BrickType.Basic;

            if (!isSpecial)
            {
                BrickBehavior brickBehavior = m_bricks[i].AddComponent<BrickBehavior>();
            }
            else
            { HandleSpecialBrick(type, m_rowData.P_BrickData[i], i); }

            m_bricks[i].gameObject.SetActive(m_rowData.P_ShouldBrickActive[i]);

            if (m_rowData.P_ShouldBrickActive[i]) 
                m_bricks[i].GetComponent<BrickBehavior>().Initialize(m_rowData.P_BrickData[i].P_Health);

            m_bricks[i].InitializeMovement(m_rowData.P_BrickData[i].P_TimeToMove,
                                  m_rowData.P_BrickData[i].P_DistanceToMove);
        }
    }

    private void HandleSpecialBrick(BrickType type, BrickData brickData, int i)
    {
        if (type == BrickType.Ranged)
        {
            RangedBrickBehavior rangedBrickBehavior = m_bricks[i].AddComponent<RangedBrickBehavior>();
            
            rangedBrickBehavior.P_FireRate = brickData.P_RangedData.P_FireRate;
        }
        else
        {
            ExplosiveBrickBehavior explosiveBrickBehavior = m_bricks[i].AddComponent<ExplosiveBrickBehavior>();

            explosiveBrickBehavior.P_ExplosionRange = brickData.P_ExplosiveData.P_ExplosionRange;
        }
    }
}