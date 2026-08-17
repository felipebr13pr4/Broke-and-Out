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
        m_brickBroken = PlayerPrefs.GetInt(PrefKeys.BrickBroken);
        m_timesKilled = PlayerPrefs.GetInt(PrefKeys.TimesKilled);
        m_damageTaken = PlayerPrefs.GetInt(PrefKeys.DamageTaken);
        m_damageDealt = PlayerPrefs.GetInt(PrefKeys.DamageDealt);
        m_basicBricksBroken = PlayerPrefs.GetInt(PrefKeys.BasicBricksBroken);
        m_rangedBricksBroken = PlayerPrefs.GetInt(PrefKeys.RangedBricksBroken);
        m_explosiveBricksBroken = PlayerPrefs.GetInt(PrefKeys.ExplosiveBricksBroken);
    }

    private void OnEnable()
    {
        BrickBehavior.OnDeath += HandleBrickStats;
        EntityBehavior.OnDamageTaken += HandleDamageStats;
        PlayerBehavior.OnDeath += HandleDeathStats;
    }

    private void OnDisable()
    {
        BrickBehavior.OnDeath -= HandleBrickStats;
        EntityBehavior.OnDamageTaken -= HandleDamageStats;
        PlayerBehavior.OnDeath -= HandleDeathStats;
    }

    private void HandleBrickStats(BrickType type)
    {
        m_brickBroken += 1;

        if (type == BrickType.Basic) m_basicBricksBroken += 1;
        if (type == BrickType.Ranged) m_rangedBricksBroken += 1;
        if (type == BrickType.Explosive) m_explosiveBricksBroken += 1;
    }

    private void HandleDeathStats() => m_timesKilled += 1;
    
    private void HandleDamageStats(GameObject receiver, int damage)
    {
        if (receiver.GetComponent<PlayerBehavior>() != null) m_damageTaken += damage;
        if (receiver.GetComponent<BrickBehavior>() != null) m_damageDealt += damage;
    }

}
