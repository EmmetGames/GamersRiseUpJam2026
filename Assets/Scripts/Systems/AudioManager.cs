using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    [SerializeField] private AudioSource[] _sfxSources;
    [SerializeField] private AudioSource[] _musicSources;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        AudioSource audioSource = GetAvailableSource(_sfxSources, clip);
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning("No available audio sources");
        }
    }
    
    public void PlayMusic(AudioClip clip, bool loop = true, bool fadeIn = false)
    {
        AudioSource audioSource = GetAvailableSource(_musicSources, clip);
        if (audioSource == null)
        {
            Debug.LogWarning("No available audio sources");
            return;
        }
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
        if (fadeIn)
        {
            StartCoroutine(FadeIn(audioSource, 1f));
        }
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration, float startVolume = 0f, float targetVolume = 1f)
    {
        audioSource.volume = startVolume;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
    }

    private AudioSource GetAvailableSource(AudioSource[] sources, AudioClip clip)
    {
        foreach (AudioSource source in sources)
        {
            if (!source.isPlaying || source.clip == clip)
            {
                return source;
            }
        }

        return null;
    }
    
    public static AudioManager Instance => _instance;
}
