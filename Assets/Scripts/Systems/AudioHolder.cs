using System;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    [SerializeField] private AudioData[] m_audioData = new AudioData[4];
    public static event Action<AudioData> OnAudio;
    public static event Action<AudioData> OnStoppableAudio;

    public void ActivateSound(params int[] indices)
    {
        for (int i = 0; i < indices.Length; i++)
            OnAudio?.Invoke(m_audioData[indices[i]]);
    }

    public void ActivateStoppableSound(params int[] indices)
    {
        for (int i = 0; i < indices.Length; i++)
            OnStoppableAudio?.Invoke(m_audioData[indices[i]]);
    }

    private void OnValidate()
    {
        for (int i = 0; i < m_audioData.Length; i++) 
        {
            float pitch;
            float min;
            float max;
            AudioData defaultData = new(m_audioData[i].P_Clip);
            if (!m_audioData[i].P_IsPitchRandom)
            {
                pitch = m_audioData[i].P_Pitch;
                if (m_audioData[i].P_Pitch == 0) pitch = defaultData.P_Pitch;
                m_audioData[i] = new(m_audioData[i].P_Clip, pitch,
                    m_audioData[i].P_IsPitchRandom, m_audioData[i].P_Min, m_audioData[i].P_Max);
            }
            else
            {
                min = m_audioData[i].P_Min;
                max = m_audioData[i].P_Max;
                if (m_audioData[i].P_Min == 0) min = defaultData.P_Min;
                if (m_audioData[i].P_Max == 0) max = defaultData.P_Max;
                m_audioData[i] = new(m_audioData[i].P_Clip, m_audioData[i].P_Pitch,
                    m_audioData[i].P_IsPitchRandom, min, max);
            }
        }
    }
}