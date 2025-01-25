using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    //Reference this script in any other script and call PlaySound() from that other script

    private List<AudioSource> audioSources;

    void Update()
    {
        if (audioSources != null)
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                if (!audioSources[i].isPlaying)
                {
                    Destroy(audioSources[i]);
                    audioSources.RemoveAt(i);
                }
            }
        }
    }

    public void PlaySound(AudioClip clip, float vol, float pitch)
    {
        gameObject.AddComponent<AudioSource>();
        audioSources = GetComponents<AudioSource>().ToList();
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioSources[i].clip != null)
            {
                continue;
            }
            else
            {
                audioSources[i].playOnAwake = false;
                audioSources[i].clip = clip;
                audioSources[i].volume = vol;
                audioSources[i].pitch = pitch;
                audioSources[i].Play();
                break;
            }
        }

    }

    public void PlaySound(AudioClip clip, float vol)
    {
        gameObject.AddComponent<AudioSource>();
        audioSources = GetComponents<AudioSource>().ToList();
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioSources[i].clip != null)
            {
                continue;
            }
            else
            {
                audioSources[i].playOnAwake = false;
                audioSources[i].clip = clip;
                audioSources[i].volume = vol;
                audioSources[i].Play();
                break;
            }
        }

    }

    public void PlaySound(AudioClip clip)
    {
        gameObject.AddComponent<AudioSource>();
        audioSources = GetComponents<AudioSource>().ToList();
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioSources[i].clip != null)
            {
                continue;
            }
            else
            {
                audioSources[i].playOnAwake = false;
                audioSources[i].clip = clip;
                audioSources[i].Play();
                break;
            }
        }

    }
}
