using UnityEngine;

[RequireComponent(typeof(Transform))]
public class BulletsHolder : MonoBehaviour
{
    public static Transform S_Transform;

    private void Awake()
    {
        S_Transform = GetComponent<Transform>();
    }
}
