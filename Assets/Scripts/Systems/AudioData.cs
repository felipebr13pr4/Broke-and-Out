using System;
using UnityEngine;

[Serializable]
public struct AudioData
{
    [SerializeField] private AudioClip m_clip;
    [SerializeField] private float m_pitch;
    [SerializeField] private bool m_isPitchRandom;
    [SerializeField] private float m_min;
    [SerializeField] private float m_max;

    public readonly AudioClip P_Clip => m_clip;
    public readonly float P_Pitch => m_pitch;
    public readonly bool P_IsPitchRandom => m_isPitchRandom;
    public readonly float P_Min => m_min;
    public readonly float P_Max => m_max;

    public AudioData(AudioClip clip)
    {
        m_clip = clip;
        m_pitch = 1;
        m_isPitchRandom = true;
        m_min = 0.75f;
        m_max = 1.25f;
    }

    public AudioData(AudioClip clip, float pitch, bool isRandomPitch, float min, float max)
    {
        m_clip = clip;
        m_pitch = pitch;
        m_isPitchRandom = isRandomPitch;
        m_min = min;
        m_max = max;
    }
}