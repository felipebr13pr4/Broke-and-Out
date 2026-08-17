using System;
using UnityEngine;

public class AchievementBoxesCreator : MonoBehaviour
{
    [SerializeField] private BoxesToSpawn[] m_boxes;
    [SerializeField] private GameObject m_boxPrefab;

    [ContextMenu("Spawn Achievement boxes")]
    private void HandleSpawnBoxes()
    {
        for (int i = 0; i < m_boxes.Length; i++)
        {
            SpawnBoxes(m_boxes[i]);
        }
    }

    private void SpawnBoxes(BoxesToSpawn boxesToSpawn)
    {
        GameObject boxPrefab;
        int increasedReq = 0;
        for (int i = 0; i < boxesToSpawn.P_BoxesAmount; i++)
        {
            boxPrefab = Instantiate(m_boxPrefab, transform);
            string boxName = boxesToSpawn.P_BoxesName + " " + (i + 1);
            boxPrefab.name = boxName;
            AchievementBox box = boxPrefab.GetComponent<AchievementBox>();
            box.Initialize(boxName, boxesToSpawn.P_BoxesType,boxesToSpawn.P_BoxesInitialReq + increasedReq);
            increasedReq += boxesToSpawn.P_BoxesReqIncrease;
        }
    }


    [ContextMenu("Clear Achievement boxes")]
    private void ClearBoxes()
    {
        AchievementBox[] boxes = GetComponentsInChildren<AchievementBox>();
        foreach (AchievementBox box in boxes)
        {
            DestroyImmediate(box.gameObject);
        }
    }

    [Serializable]
    public struct BoxesToSpawn
    {
        [SerializeField] private string m_boxesName;
        [SerializeField] private int m_boxesAmount;
        [SerializeField] private AchievementType m_boxesType;
        [SerializeField] private int m_boxesInitialReq;
        [SerializeField] private int m_boxesReqIncrease;

        public readonly string P_BoxesName => m_boxesName;
        public readonly int P_BoxesAmount => m_boxesAmount;
        public readonly AchievementType P_BoxesType => m_boxesType;
        public readonly int P_BoxesInitialReq => m_boxesInitialReq;
        public readonly int P_BoxesReqIncrease => m_boxesReqIncrease;

    }
}
