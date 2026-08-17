using System.Collections;
using UnityEngine;
public class RangedBrickBehavior : BrickBehavior
{
    [SerializeField] private float m_fireRate;
    public float P_FireRate { get => m_fireRate; set { m_fireRate = value; } }
    private GameObject[] m_bullets;
    private readonly int m_maxBullets = 9;
    protected override Color P_Color { get; set; } = new(1, 1, 0.2f, 1);
    protected override BrickType P_BrickType { get; set; } = BrickType.Ranged;

    public override void Initialize(int health)
    {
        base.Initialize(health);
        m_bullets = new GameObject[m_maxBullets];
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool canShoot = false;
        while (!canShoot)
        {
            canShoot = !CheckIfBricksInWay();
            yield return new WaitForSeconds(2f);
        }
        for (int i = 0; i < m_bullets.Length; i++)
        {
            yield return new WaitForSeconds(m_fireRate);
            m_bullets[i] = new GameObject("Bullet Brick");
            m_bullets[i].AddComponent<BulletBrick>();
            BulletBrick bullet = m_bullets[i].GetComponent<BulletBrick>();
            bullet.InitializeBullet(P_SpriteRen.sprite, transform);
        }
        while (true)
        {
            for (int i = 0; i < m_bullets.Length; i++)
            {
                yield return new WaitForSeconds(m_fireRate);
                if (!gameObject.activeInHierarchy) yield break;
                if (!m_bullets[i].gameObject.activeInHierarchy) m_bullets[i].gameObject.SetActive(true);
                m_bullets[i].transform.position = transform.position;
            }
        }
    }

    private bool CheckIfBricksInWay()
    {
        bool result = false;

        float sizeAdjustmentY = (transform.localScale.y / 2) + 0.1f;
        Vector2 origin = new(transform.position.x, transform.position.y-sizeAdjustmentY);

        LayerMask layer = 1 << LayerMask.NameToLayer("Brick");

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down,
                                             5, layer);

        Debug.DrawRay(origin, Vector2.down*5, Color.red, 1f);

        if (hit.collider != null) result = true;

        return result;
    }
}
