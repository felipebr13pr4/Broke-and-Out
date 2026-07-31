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
        
        RandomBricks();

        for (int i = 0; i < m_rows.Length; i++)
        {
            m_rows[i].P_RowData = m_rowData[i];
            m_rows[i].P_IsLocked = false;
        }
    }

    private void RandomBricks()
    {
        for (int i = 0; i < 5; i++)
        {
            //test
            for (int j = 0; j < 11; j++)
            {
                int healthRandomness = Random.Range(1, 4);
                m_rowData[i].P_BrickData[j].P_Health = healthRandomness;

                int typeRandomness = Random.Range(0, 3);
                BrickType type = typeRandomness == 0 ? BrickType.Basic :
                                 typeRandomness == 1 ? BrickType.Ranged : BrickType.Explosive;
                m_rowData[i].P_BrickData[j].P_BrickType = type;

                if (type != BrickType.Basic) HandleSpecialBrick(type, i, j);

                m_rowData[i].P_BrickData[j].P_TimeToMove = 3;
                m_rowData[i].P_BrickData[j].P_DistanceToMove = 1;

                int activeRandomness = Random.Range(0, 2);
                m_rowData[i].P_ShouldBrickActive[j] = activeRandomness == 1 ? true : false;

                print(m_rowData[i].P_BrickData[j].P_RangedData.P_FireRate + " " + type);
            }
            //test
        }
    }

    private void HandleSpecialBrick(BrickType type, int i, int j)
    {
        if (type == BrickType.Ranged)
        {
            float fireRateRandomness = Random.Range(1f, 10f);
            m_rowData[i].P_BrickData[j].P_RangedData.P_FireRate = fireRateRandomness;
        } else
        {
            int explosionRandomness = Random.Range(1, 3);
            print("random explo: " + explosionRandomness);
            m_rowData[i].P_BrickData[j].P_ExplosiveData.P_ExplosionRange = explosionRandomness;
        }
    }
}
