using UnityEngine;
using UnityEngine.InputSystem;

public class TesterController : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame) SceneController.Instance.ReloadScene();
        if (Keyboard.current.qKey.wasPressedThisFrame)
        { if (Time.timeScale <= 0.1f) return; Time.timeScale -= 0.1f; }
        if (Keyboard.current.eKey.wasPressedThisFrame) Time.timeScale += 0.1f;
        if (Keyboard.current.zKey.wasPressedThisFrame) Time.timeScale = 1;
        if (Keyboard.current.xKey.wasPressedThisFrame) Time.timeScale = 2;
        if (Keyboard.current.cKey.wasPressedThisFrame) Time.timeScale = 3;
    }
}
