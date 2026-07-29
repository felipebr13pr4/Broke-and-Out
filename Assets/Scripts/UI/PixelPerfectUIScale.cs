using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(CanvasScaler))]
public class PixelPerfectUIScale : MonoBehaviour
{
    private readonly int m_referenceWidth = 1080;
    private CanvasScaler m_scaler;
    private int m_lastWidth = 0;

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
        if (Screen.width != m_lastWidth || Screen.fullScreenMode != FullScreenMode.FullScreenWindow)
        {
            m_lastWidth = Screen.width;
            float scale = Mathf.Max(0.21f, (float)(Screen.width) / (float)(m_referenceWidth));
            m_scaler.scaleFactor = scale;
        }
    }
}