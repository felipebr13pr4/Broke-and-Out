[System.Serializable]
public struct BrickData
{
    public int P_Health;
    public BrickType P_BrickType;
    public float P_TimeToMove;
    public float P_DistanceToMove;
    public RangedBrickData P_RangedData;
    public ExplosiveBrickData P_ExplosiveData;

    public void Default()
    {
        P_Health = 1;
        P_BrickType = BrickType.Basic;
        P_TimeToMove = 3;
        P_DistanceToMove = 1;
        RangedBrickData ranged = new();
        ExplosiveBrickData explosive = new();
        ranged.Default();
        explosive.Default();
        P_RangedData = ranged;
        P_ExplosiveData = explosive;
    }
}