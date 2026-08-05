using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private float m_audioVolume = 1;

    private AudioSource m_audioSource;

    public AudioSource P_AudioSource => m_audioSource;
    public float P_AudioVolume => m_audioVolume;

    public static AudioController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        AudioHolder.OnAudio += PlayAudio;
    }

    private void OnDisable()
    {
        AudioHolder.OnAudio -= PlayAudio;
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioVolume = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void PlayAudio(AudioData data)
    {
        float pitch = data.P_Pitch;
        if (data.P_IsPitchRandom) pitch = Random.Range(data.P_Min, data.P_Max);
        m_audioSource.pitch = pitch;
        m_audioSource.PlayOneShot(data.P_Clip, m_audioVolume);
    }

    public void PlayAudio(AudioClip clip)
    {
        m_audioSource.pitch = Random.Range(0.75f, 1.25f);
        m_audioSource.PlayOneShot(clip, m_audioVolume);
    }

    public void SetAudio(float value)
    {
        m_audioVolume = value;
    }
}