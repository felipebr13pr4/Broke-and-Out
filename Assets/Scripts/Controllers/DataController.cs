using UnityEngine;

public class DataController : MonoBehaviour
{
    private int m_brickBroken;
    private int m_timesKilled;
    private int m_damageTaken;
    private int m_damageDealt;
    private int m_basicBricksBroken;
    private int m_rangedBricksBroken;
    private int m_explosiveBricksBroken;

    public int P_BrickBroken => m_brickBroken;
    public int P_TimesKilled => m_timesKilled;
    public int P_DamageTaken => m_damageTaken;
    public int P_DamageDealt => m_damageDealt;
    public int P_BasicBricksBroken => m_basicBricksBroken;
    public int P_RangedBricksBroken => m_rangedBricksBroken;
    public int P_ExplosiveBricksBroken => m_explosiveBricksBroken;

    private int m_currentLevel;
    public int P_CurrentLevel { get => m_currentLevel;
        set { value = Mathf.Clamp(value, 0, 40); m_currentLevel = value; }
    }


    public static DataController Instance { get; private set; }
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
        m_brickBroken = PlayerPrefs.GetInt("Brick Broken");
        m_timesKilled = PlayerPrefs.GetInt("Times Killed");
        m_damageTaken = PlayerPrefs.GetInt("Damage Taken");
        m_damageDealt = PlayerPrefs.GetInt("Damage Dealt");
        m_basicBricksBroken = PlayerPrefs.GetInt("Basic Bricks Broken");
        m_rangedBricksBroken = PlayerPrefs.GetInt("Ranged Bricks Broken");
        m_explosiveBricksBroken = PlayerPrefs.GetInt("Explosive Bricks Broken");
        P_CurrentLevel = PlayerPrefs.GetInt("Current Level");
    }

    private void OnEnable()
    {
        BrickBehavior.OnDeath += HandleBrickStats;
        EntityBehavior.OnDamageTaken += HandleDamageStats;
        PlayerBehavior.OnDeath += HandleDeathStats;
        LevelButton.OnLevelChanged += ChangeLevel;
    }

    private void OnDisable()
    {
        BrickBehavior.OnDeath -= HandleBrickStats;
        EntityBehavior.OnDamageTaken -= HandleDamageStats;
        PlayerBehavior.OnDeath -= HandleDeathStats;
        LevelButton.OnLevelChanged -= ChangeLevel;
    }

    private void HandleBrickStats(BrickType type)
    {
        m_brickBroken += 1;
        print("type: " + type);

        if (type == BrickType.Basic) m_basicBricksBroken += 1;
        if (type == BrickType.Ranged) { print("type: " + type); m_rangedBricksBroken += 1; }
        if (type == BrickType.Explosive) m_explosiveBricksBroken += 1;
    }

    private void HandleDeathStats() => m_timesKilled += 1;
    
    private void HandleDamageStats(GameObject receiver, int damage)
    {
        if (receiver.GetComponent<PlayerBehavior>() != null) m_damageTaken += damage;
        if (receiver.GetComponent<BrickBehavior>() != null) m_damageDealt += damage;
    }

    private void ChangeLevel(int level) => P_CurrentLevel = level;
}
