using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(CanvasScaler))]
public class PixelPerfectUIScale : MonoBehaviour
{
    private readonly int m_referenceHeight = 1920;
    private CanvasScaler m_scaler;
    private int m_lastHeight = 0;

    private void Start() 
    {
        m_scaler = GetComponent<CanvasScaler>();
        if (m_scaler.uiScaleMode != CanvasScaler.ScaleMode.ConstantPixelSize)
            m_scaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
    }


    private void Update()
    {
        ChangeScale();
    }

    private void ChangeScale()
    {
        if (Screen.height != m_lastHeight || Screen.fullScreenMode != FullScreenMode.FullScreenWindow)
        {
            m_lastHeight = Screen.height;
            float scale = (float)(Screen.height) / (float)(m_referenceHeight);
            m_scaler.scaleFactor = Mathf.Clamp(scale, 0.21f, 1f);
        }
    }
}