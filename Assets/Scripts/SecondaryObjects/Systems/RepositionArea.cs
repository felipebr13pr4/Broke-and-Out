using System.Collections;
using UnityEngine;

public class RepositionArea : MonoBehaviour
{
    private bool m_isBrickInside = false;
    public bool P_IsBrickinside => m_isBrickInside;

    private void FixedUpdate() => CheckIfSomethingInside();

    private void CheckIfSomethingInside()
    {
        LayerMask layer = 1 << LayerMask.NameToLayer("Brick");

        Collider2D hit = Physics2D.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity.eulerAngles.x, layer);

        m_isBrickInside = hit != null;
    }

    [ContextMenu("Adjust X Size To Camera")]
    private void AdjustXSize()
    {
        transform.localScale = new(ScreenBounds.Right*2, transform.localScale.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Application.isPlaying)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
