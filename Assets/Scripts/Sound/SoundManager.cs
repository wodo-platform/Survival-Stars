using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip[] _audioClips;
    
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusic(SoundType soundType)
    {
        _musicSource.Stop();
        _musicSource.clip = _audioClips[(int)soundType];
        _musicSource.Play();
        _musicSource.loop = soundType == SoundType.GameMusic;
    }

    public void PlaySfx(SoundType soundType)
    {
        _sfxSource.Stop();
        _sfxSource.clip = _audioClips[(int)soundType];
        _sfxSource.Play();
    }
}

public enum SoundType
{
    GameMusic,
    GameOverMusic,
    DamageSFX,
    HealthCollectSFX,
    CoinCollectSFX
}
