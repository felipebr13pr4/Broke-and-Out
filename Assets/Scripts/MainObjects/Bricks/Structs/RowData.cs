[System.Serializable]
public struct RowData
{
    public bool[] P_ShouldBrickActive;
    public BrickData[] P_BrickData;
    public void Default()
    {
        int bricksAmount = 11;
        P_ShouldBrickActive = new bool[bricksAmount];
        P_BrickData = new BrickData[bricksAmount];

        for (int i = 0; i < bricksAmount; i++) 
        {
            P_ShouldBrickActive[i] = false;
            P_BrickData[i].Default(); 
        }

    }
}