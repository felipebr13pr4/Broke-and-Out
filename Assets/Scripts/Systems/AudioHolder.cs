using System;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_audioClip;
    public static event Action<AudioClip> OnAudio;

    public void ActivateSound(int i, int j = 999, int k = 999, int l = 999)
    {
        OnAudio(m_audioClip[i]);
        if (j != 999 && j < m_audioClip.Length) OnAudio(m_audioClip[j]);
        if (k != 999 && k < m_audioClip.Length) OnAudio(m_audioClip[k]);
        if (l != 999 && l < m_audioClip.Length) OnAudio(m_audioClip[l]);
    }
}
