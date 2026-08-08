using System;
using UnityEngine;
using UnityEngine.UI;

public class QuickLevelChangeButton : LevelButton
{
    [SerializeField] private bool m_isIncreaser;

    protected override void ChangeLevel()
    {
        int currentLevel = DataController.Instance.P_CurrentLevel;
        m_assignedLevel = m_isIncreaser ? currentLevel+1 : currentLevel-1;
        base.ChangeLevel();
    }
}
