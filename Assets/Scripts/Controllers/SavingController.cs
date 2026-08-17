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

    private void OnApplicationQuit()
    {
        SaveAll();
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
        PlayerPrefs.SetInt(PrefKeys.BrickBroken, DataController.Instance.P_BrickBroken);
        PlayerPrefs.SetInt(PrefKeys.TimesKilled, DataController.Instance.P_TimesKilled);
        PlayerPrefs.SetInt(PrefKeys.DamageTaken, DataController.Instance.P_DamageTaken);
        PlayerPrefs.SetInt(PrefKeys.DamageDealt, DataController.Instance.P_DamageDealt);
        PlayerPrefs.SetInt(PrefKeys.BasicBricksBroken, DataController.Instance.P_BasicBricksBroken);
        PlayerPrefs.SetInt(PrefKeys.RangedBricksBroken, DataController.Instance.P_RangedBricksBroken);
        PlayerPrefs.SetInt(PrefKeys.ExplosiveBricksBroken, DataController.Instance.P_ExplosiveBricksBroken);
        PlayerPrefs.SetInt(PrefKeys.CurrentLevel, LevelController.Instance.P_CurrentLevel);
        PlayerPrefs.SetInt(PrefKeys.RandomMode, LevelController.Instance.P_IsRandomMode ? 1 : 0);
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat(PrefKeys.Volume, AudioController.Instance.P_AudioVolume);
        PlayerPrefs.SetInt(PrefKeys.ScreenWidth, Screen.width);
        PlayerPrefs.SetInt(PrefKeys.ScreenHeight, Screen.height);
        PlayerPrefs.SetInt(PrefKeys.FullScreen, Screen.fullScreenMode == FullScreenMode.FullScreenWindow ? 1 : 0);
    }
}