using UnityEngine;
public class RangedBrickBehavior : BrickBehavior
{
    [SerializeField] private float m_fireRate;

    public void Initialize(int health, float fireRate)
    {
        m_fireRate = fireRate;
        P_Health = health;
        SetHealth(health);
    }

    private void Shoot()
    {
        // TODO
    }
}
