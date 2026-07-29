using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip m_audioBallHitScreen;
    [SerializeField] private AudioClip m_audioBallFell;
    [SerializeField] private AudioClip m_audioPaddleHit;
    [SerializeField] private AudioClip m_audioPauseWindowOpen;
    [SerializeField] private AudioClip m_audioBreakBrick;

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

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioVolume = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void PlayAudio(AudioType type)
    {
        m_audioSource.pitch = Random.Range(0.75f, 1.25f);
        switch (type)
        {
            case AudioType.BallHitScreen:
                m_audioSource.PlayOneShot(m_audioBallHitScreen, m_audioVolume); return;

            case AudioType.BallFell:
                m_audioSource.PlayOneShot(m_audioBallFell, m_audioVolume); return;

            case AudioType.PaddleHit:
                m_audioSource.PlayOneShot(m_audioPaddleHit, m_audioVolume); return;

            case AudioType.PauseWindowOpen:
                m_audioSource.PlayOneShot(m_audioPauseWindowOpen, m_audioVolume); return;

            case AudioType.BreakBrick:
                m_audioSource.PlayOneShot(m_audioBreakBrick, m_audioVolume); return;
        }
    }

    public void SetAudio(float value)
    {
        m_audioVolume = value;
    }
}