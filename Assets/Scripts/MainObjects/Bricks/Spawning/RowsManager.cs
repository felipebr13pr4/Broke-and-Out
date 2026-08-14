using System.Collections;
using System.IO;
using UnityEngine;

public class RowsManager : MonoBehaviour
{
    [SerializeField] private BrickRowBehavior[] m_rows;
    [SerializeField] private GameObject m_brickCurtain;
    private LevelData m_levelData;

    private void Start()
    {
        m_levelData.P_Rows = new RowData[m_rows.Length];
        for (int i = 0; i < m_levelData.P_Rows.Length; i++)
        {
            m_levelData.P_Rows[i].P_ShouldBrickActive = new bool[11];
            m_levelData.P_Rows[i].P_BrickData = new BrickData[11];
        }

        string path = Application.persistentDataPath +
            $"/Level{LevelController.Instance.P_CurrentLevel}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LevelData level = JsonUtility.FromJson<LevelData>(json);
            m_levelData = level;
        }

        StartCoroutine(HandleRows());
    }

    private IEnumerator HandleRows()
    {
        yield return null;

        if (LevelController.Instance.P_IsRandomMode) RandomBricks();

        for (int i = 0; i < m_rows.Length; i++)
        {
            m_rows[i].P_RowData = m_levelData.P_Rows[i];
            m_rows[i].P_IsLocked = false;
        }

        yield return new WaitForSeconds(0.01f);

        m_brickCurtain.SetActive(false);

    }

    private void RandomBricks()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                int healthRandomness = Random.Range(1, 4);
                m_levelData.P_Rows[i].P_BrickData[j].P_Health = healthRandomness;
                print(m_levelData.P_Rows[i].P_BrickData[j].P_Health + " health");

                int typeRandomness = Random.Range(0, 3);
                BrickType type = typeRandomness == 0 ? BrickType.Basic :
                                 typeRandomness == 1 ? BrickType.Ranged : BrickType.Explosive;
                m_levelData.P_Rows[i].P_BrickData[j].P_BrickType = type;

                if (type != BrickType.Basic) HandleSpecialBrick(type, i, j);

                m_levelData.P_Rows[i].P_BrickData[j].P_TimeToMove = 3;
                m_levelData.P_Rows[i].P_BrickData[j].P_DistanceToMove = 1;

                int activeRandomness = Random.Range(0, 2);
                m_levelData.P_Rows[i].P_ShouldBrickActive[j] = activeRandomness == 1;

                print(m_levelData.P_Rows[i].P_BrickData[j].P_RangedData.P_FireRate + " " + type);
            }
        }
    }

    private void HandleSpecialBrick(BrickType type, int i, int j)
    {
        if (type == BrickType.Ranged)
        {
            float fireRateRandomness = SkewedRandom(2f, 12f, 2f);
            m_levelData.P_Rows[i].P_BrickData[j].P_RangedData.P_FireRate = fireRateRandomness;
        } else
        {
            Vector2 explosionRandomness = new(SkewedRandom(2f, 12f, 2.5f), SkewedRandom(2f, 12f, 2.5f));
            print("random explosion: " + explosionRandomness);
            m_levelData.P_Rows[i].P_BrickData[j].P_ExplosiveData.P_ExplosionRange = explosionRandomness;
        }
    }

    private float SkewedRandom(float min, float max, float bias)
    {
        float r = Mathf.Pow(Random.value, bias);
        return Mathf.Lerp(min, max, r);
    }
}
