[System.Serializable]
public struct LevelData
{
    public RowData[] P_Rows;
    public void Default(int rowsAmount = 5)
    { 
        P_Rows = new RowData[rowsAmount]; 
        for(int i = 0; i < P_Rows.Length; i++) P_Rows[i].Default();
    }
}