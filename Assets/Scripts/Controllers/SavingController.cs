using System.Collections;
using UnityEngine;

public class SavingController : MonoBehaviour
{
    private bool m_isAutoSaveOn = true;

    public static SavingController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(AutoSave());
    }

    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(15);
            if (m_isAutoSaveOn) Save();
        }
    }

    public void SaveAll()
    {
        Save();
        SavePlayerPrefs();
        PlayerPrefs.Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Brick Broken", DataController.Instance.P_BrickBroken);
        PlayerPrefs.SetInt("Times Killed", DataController.Instance.P_TimesKilled);
        PlayerPrefs.SetInt("Damage Taken", DataController.Instance.P_DamageTaken);
        PlayerPrefs.SetInt("Damage Dealt", DataController.Instance.P_DamageDealt);
        PlayerPrefs.SetInt("Basic Bricks Broken", DataController.Instance.P_BasicBricksBroken);
        PlayerPrefs.SetInt("Ranged Bricks Broken", DataController.Instance.P_RangedBricksBroken);
        PlayerPrefs.SetInt("Explosive Bricks Broken", DataController.Instance.P_ExplosiveBricksBroken);
        PlayerPrefs.SetInt("Current Level", LevelController.Instance.P_CurrentLevel);
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("Volume", AudioController.Instance.P_AudioVolume);
        PlayerPrefs.SetInt("Screen Width", Screen.width);
        PlayerPrefs.SetInt("Screen Height", Screen.height);
        PlayerPrefs.SetInt("Full Screen", Screen.fullScreenMode == FullScreenMode.FullScreenWindow ? 1 : 0);
    }
}