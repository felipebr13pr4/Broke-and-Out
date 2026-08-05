using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CreationsHolder : MonoBehaviour
{
    public static Transform S_Transform;

    private void Awake()
    {
        S_Transform = GetComponent<Transform>();
    }
}
