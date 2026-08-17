using UnityEngine;

[System.Serializable]
public struct ExplosiveBrickData
{
    public Vector2 P_ExplosionRange;
    public void Default()
    {
        P_ExplosionRange = new(3, 3);
    }
}