using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioClip bgmClip;
    public AudioClip[] sfxClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM()
    {
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.Play();
            print("BGM Playing: " + bgmClip.name);
        }
    }

    public void PlaySFX(int clipIndex)
    {
        if (sfxSource != null && clipIndex >= 0 && clipIndex < sfxClips.Length)
        {
            sfxSource.clip = sfxClips[clipIndex];
            sfxSource.Play();
            print("SFX Playing: " + sfxClips[clipIndex].name);
        }
    }

    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
            print("BGM Stopped");
        }
    }
}
