using UnityEngine;

public class QuickLevelChangeButton : LevelButton
{
    [SerializeField] private bool m_isIncreaser;

    protected override void ChangeLevel()
    {
        int currentLevel = LevelController.Instance.P_CurrentLevel;
        m_assignedLevel = m_isIncreaser ? currentLevel+1 : currentLevel-1;
        base.ChangeLevel();
    }
}
