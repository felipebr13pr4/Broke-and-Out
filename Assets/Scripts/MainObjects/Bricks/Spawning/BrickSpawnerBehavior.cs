using System.Collections;
using UnityEngine;

public class BrickSpawnerBehavior : MonoBehaviour
{
    [SerializeField] private BrickRowBehavior[] m_rows;
    private RowData[] m_rowData;

    private void Start()
    {
        m_rowData = new RowData[m_rows.Length];
        for (int i = 0; i < m_rowData.Length; i++)
        {
            m_rowData[i].P_BrickData = new BrickData[11];
            m_rowData[i].P_ShouldBrickActive = new bool[11];
        }
        StartCoroutine(HandleRows());
    }

    private IEnumerator HandleRows()
    {
        yield return new WaitForSeconds(0.01f);
        for (int i = 0; i < 5; i++)
        {
            //test
            for (int j = 0; j < 11; j++)
            {
                m_rowData[i].P_BrickData[j].P_timeToMove = 3;
                m_rowData[i].P_BrickData[j].P_distanceToMove = 1;
                int randomness = Random.Range(0, 2);
                m_rowData[i].P_ShouldBrickActive[j] = randomness == 1 ? true : false;
            }
            //test
        }

        for (int i = 0; i < m_rows.Length; i++)
        {
            m_rows[i].P_RowData = m_rowData[i];
            m_rows[i].P_IsLocked = false;
        }
    }
}
