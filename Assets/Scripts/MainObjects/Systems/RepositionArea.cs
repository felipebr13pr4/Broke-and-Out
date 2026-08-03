using UnityEngine;

public class RepositionArea : MonoBehaviour
{
    private bool m_isBrickInside = false;
    public bool P_IsBrickinside => m_isBrickInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Brick")) return;
        m_isBrickInside = true;
        print("m_isBrickInside = " + m_isBrickInside);
    }

    [ContextMenu("Adjust X Size To Camera")]
    private void AdjustXSize()
    {
        transform.localScale = new(ScreenBounds.Right*2, transform.localScale.y);
    }
}
