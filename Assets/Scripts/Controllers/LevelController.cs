using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelData[] m_levels;
    public LevelData[] P_Levels => m_levels;
    [SerializeField] private bool m_safetyLockFromDefaultAll = true;
    [SerializeField] private int m_targetLevel = 0;
    [TextArea(5,1000)]
    [SerializeField] private string m_levelString;
    private int m_currentRow;
    private bool m_firstTime = true;
    private int m_rowsCleared;
    public int P_RowsCleared { get => m_rowsCleared; set => m_rowsCleared = value; }
    private bool m_isRandomMode;
    public bool P_IsRandomMode { get => m_isRandomMode; set => m_isRandomMode = value; }
    private int m_currentLevel;
    public int P_CurrentLevel
    {
        get => m_currentLevel;
        set { value = Mathf.Clamp(value, 0, 40); m_currentLevel = value; }
    }

    public static LevelController Instance { get; private set; }
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
        P_CurrentLevel = PlayerPrefs.GetInt("Current Level");
        if (m_firstTime)
        {
            for (int i = 0; i < m_levels.Length; i++)
            {
                string json = JsonUtility.ToJson(m_levels[i], true);
                File.WriteAllText(Application.persistentDataPath + $"/Level{i}.json", json);
                print(json);
            }
            m_firstTime = false;
        }
    }

    private void OnEnable()
    {
        LevelButton.OnLevelChanged += ChangeLevel;
    }

    private void OnDisable()
    {
        LevelButton.OnLevelChanged -= ChangeLevel;
    }
    private void ChangeLevel(int level) => P_CurrentLevel = level;


    [ContextMenu("Default ALL Levels")]
    private void InitializeDefaultLevels()
    {
        if (m_safetyLockFromDefaultAll) return;
        for (int i = 0; i < m_levels.Length; i++) 
        {
            if (m_levels[i].P_Rows.Length > 0) continue;
            m_levels[i].Default();
        }
    }

    [ContextMenu("---")]
    [ContextMenu("2 Initialize Default Level")]
    private void InitializeDefaultLevel()
    {
        if (m_levels[m_targetLevel].P_Rows.Length > 0) return;
        m_levels[m_targetLevel].Default();
    }

    [ContextMenu("3 Initialize Level")]
    private void InitializeLevel()
    {
        m_levels[m_targetLevel] = new LevelData();
        m_levels[m_targetLevel].Default();

        string[] tempString = m_levelString.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None); ;
        string currentType = "";
        print("tempString lenght: " + tempString.Length);
        
        for (int i = 0; i < tempString.Length; i++)
        {
            if (tempString[i] == "") continue;
            string identify = tempString[i].StartsWith('[') ? "DATA: " : "MARKER: ";
            print(identify + tempString[i]);

            if (tempString[i].StartsWith('-'))
            {
                currentType = tempString[i].Trim('-');
                m_currentRow = 4;
            }

            if (identify == "DATA: ")
            {
                HandleType(currentType, i, m_currentRow, tempString[i]);
                m_currentRow -= 1;
            }
        }
    }

    private void HandleType(string type, int index, int row, string data)
    {
        List<string> result = new List<string>();
        string[] tempData;
        tempData = data.Split('[');
        for (int i = 0; i < tempData.Length; i++)
        {
            if (tempData[i] == "") continue;
            result.Add(tempData[i].Split(']')[0]);
        }
        print("result count: " + result.Count);
        if (result.Count != 11)
        {
            ErrorLogger.LogError("Data Count", result.Count.ToString());
            if (result.Count < 11) { for (int i = result.Count; i < 11; i++) result.Add(""); }
            if (result.Count > 11) { for (int i = result.Count - 1; i > 11; i--) {
                    print("index: " + i); result.RemoveAt(i); } }
        }
        switch (type)
        {
            case "ACTIVE":
                for (int i = 0; i < 11; i++)
                {
                    if (result[i] != "T" & result[i] != "F")
                        ErrorLogger.LogError("Active", result[i]);
                    m_levels[m_targetLevel].P_Rows[row].P_ShouldBrickActive[i] = result[i] == "T";
                    print(m_levels[m_targetLevel].P_Rows[row].P_ShouldBrickActive[i]);
                }
                return;

            case "HEALTH":
                for (int i = 0; i < 11; i++)
                {
                    if (!int.TryParse(result[i], out _))
                    { ErrorLogger.LogError("Health", result[i]); result[i] = "1"; }
                    m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_Health = int.Parse(result[i]);
                    print(m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_Health);
                }
                return;

            case "TIME":
                for (int i = 0; i < 11; i++)
                {
                    if (!float.TryParse(result[i], out _))
                    { ErrorLogger.LogError("Move Time", result[i]); result[i] = "3"; }
                    m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_TimeToMove = float.Parse(result[i], CultureInfo.InvariantCulture);
                    print(m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_TimeToMove);
                }
                return;

            case "DISTANCE":
                for (int i = 0; i < 11; i++)
                {
                    if (!float.TryParse(result[i], out _))
                    { ErrorLogger.LogError("Move Distance", result[i]); result[i] = "1"; }
                    m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_DistanceToMove = float.Parse(result[i], CultureInfo.InvariantCulture);
                    print(m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_DistanceToMove);
                }
                return;

            case "TYPE":
                for (int i = 0; i < 11; i++)
                {
                    if (result[i] != "B" & result[i] != "R" & result[i] != "E")
                        ErrorLogger.LogError("Brick Type", result[i]);
                    m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_BrickType = result[i] switch
                    {
                        "B" => BrickType.Basic,
                        "R" => BrickType.Ranged,
                        "E" => BrickType.Explosive,
                        _ => BrickType.Basic
                    };
                    print(m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_BrickType);
                }
                return;

            case "RANGED VALUE":
                for (int i = 0; i < 11; i++)
                {
                    if (!float.TryParse(result[i], out _))
                    { ErrorLogger.LogError("Ranged Firerate", result[i]); result[i] = "3"; }
                    m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_RangedData.P_FireRate = float.Parse(result[i], CultureInfo.InvariantCulture);
                    print(m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_RangedData.P_FireRate);
                }
                return;

            case "EXPLOSION VALUE":
                tempData = new string[22];
                Vector2 vector = new();
                for (int i = 0; i < 11; i++)
                {
                    tempData = new string[2];
                    tempData = result[i].Split(',');
                    if (result[i] == "") tempData = new string[2];
                    if (!float.TryParse(tempData[0], out _) | !float.TryParse(tempData[1], out _))
                    {
                        ErrorLogger.LogError("Explosion Range", (tempData[0] + " " + tempData[1]));
                        tempData = new string[2]; tempData[0] = "3"; tempData[1] = "3";
                    }

                    vector.x = float.Parse(tempData[0], CultureInfo.InvariantCulture);
                    vector.y = float.Parse(tempData[1], CultureInfo.InvariantCulture);
                    m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_ExplosiveData.P_ExplosionRange = vector;
                    print(m_levels[m_targetLevel].P_Rows[row].P_BrickData[i].P_ExplosiveData.P_ExplosionRange);
                }
                return;

            default:
                ErrorLogger.LogError("Marker", type);
                return;
        }
    }

    [ContextMenu("4 Reset Level String")]
    private void ResetLevelString()
    {
        m_levelString =
    "--ACTIVE--\n" +
"[T][T][T][T][T][T][T][T][T][T][T]\n" +
"[F][F][F][F][F][F][F][F][F][F][F]\n" +
"[F][T][F][T][F][T][F][T][F][T][F]\n" +
"[T][F][T][F][T][F][T][F][T][F][T]\n" +
"[F][F][T][T][F][T][T][F][T][T][F]\n" +
    "--ACTIVE--" +
        "\n\n" +
    "--HEALTH--\n" +
"[1][1][1][1][1][1][1][1][1][1][1]\n" +
"[2][2][2][2][2][2][2][2][2][2][2]\n" +
"[3][3][3][3][3][3][3][3][3][3][3]\n" +
"[4][4][4][4][4][4][4][4][4][4][4]\n" +
"[5][5][5][5][5][5][5][5][5][5][5]\n" +
    "--HEALTH--\n" +
        "\n\n" +
    "--TIME--\n" +
"[1.2][1][1][1][1][1][1][1][1][1][1]\n" +
"[2][2][2][2][2][2][2][2][2][2][2]\n" +
"[3][3][3][3][3][3][3][3][3][3][3]\n" +
"[4][4][4][4][4][4][4][4][4][4][4]\n" +
"[5][5][5][5][5][5][5][5][5][5][5]\n" +
    "--TIME--\n" +
        "\n\n" +
    "--DISTANCE--\n" +
"[1.2][1][1][1][1][1][1][1][1][1][1]\n" +
"[2][2][2][2][2][2][2][2][2][2][2]\n" +
"[3][3][3][3][3][3][3][3][3][3][3]\n" +
"[4][4][4][4][4][4][4][4][4][4][4]\n" +
"[5][5][5][5][5][5][5][5][5][5][5]\n" +
    "--DISTANCE--\n" +
        "\n\n" +
    "--TYPE--\n" +
"[B][E][R][B][E][R][B][E][R][B][E]\n" +
"[E][R][B][E][R][B][E][R][B][E][R]\n" +
"[R][B][E][R][B][E][R][B][E][R][B]\n" +
"[R][E][B][R][E][B][R][E][B][R][E]\n" +
"[B][R][E][B][R][E][B][R][E][B][R]\n" +
    "--TYPE--\n" +
        "\n\n" +
    "--RANGED VALUE--\n" +
"[1.2][1][1][1][1][1][1][1][1][1][1]\n" +
"[2][2][2][2][2][2][2][2][2][2][2]\n" +
"[3][3][3][3][3][3][3][3][3][3][3]\n" +
"[4][4][4][4][4][4][4][4][4][4][4]\n" +
"[5][5][5][5][5][5][5][5][5][5][5]\n" +
    "--RANGED VALUE--\n" +
        "\n\n" +
    "--EXPLOSION VALUE--\n" +
"[1.2,1][1,1][1,1][1,1][1,1][1,1][1,1][1,1][1,1][1,1][1,1]\n" +
"[2,2][2,2][2,2][2,2][2,2][2,2][2,2][2,2][2,2][2,2][2,2]\n" +
"[3,3][3,3][3,3][3,3][3,3][3,3][3,3][3,3][3,3][3,3][3,3]\n" +
"[4,4][4,4][4,4][4,4][4,4][4,4][4,4][4,4][4,4][4,4][4,4]\n" +
"[5,5][5,5][5,5][5,5][5,5][5,5][5,5][5,5][5,5][5,5][5,5]\n" +
    "--EXPLOSION VALUE--";
    }
}