using UnityEngine;
public class RangedBrickBehavior : BrickBehavior
{
    [SerializeField] private float m_fireRate;

    protected override void Start()
    {
        base.Start();
    }

    public void Initialize(float fireRate)
    {
        m_fireRate = fireRate;
        InitializeColor(1, 1, 0.2f);
    }

    private void Shoot()
    {
        // TODO
    }
}
