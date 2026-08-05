using UnityEngine;

public class ExplosiveBrickBehavior : BrickBehavior
{
    [SerializeField] private Vector2 m_explosionRange;
    public Vector2 P_ExplosionRange { get => m_explosionRange; set { m_explosionRange = value; } }
    protected override Color P_Color { get; set; } = new(1, 0.2f, 0.2f, 1);
    private GameObject m_explosionObj;
    private Explosion m_explosion;

    public override void Initialize(int health)
    {
        base.Initialize(health);
        m_explosionObj = new GameObject("Explosion");
        m_explosionObj.SetActive(false);
        m_explosion = m_explosionObj.AddComponent<Explosion>();
        m_explosion.InitializeChildren(P_MaxHealth);
    }

    protected override void Die()
    {
        m_explosion.Initialize(P_MaxHealth, m_explosionRange, transform,
                     P_SpriteRen.sprite, m_colorData.P_ColorsStates[P_MaxHealth - 1], 0.025f); 
        base.Die();
    }
}