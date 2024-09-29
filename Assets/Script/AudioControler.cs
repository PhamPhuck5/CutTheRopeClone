using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioControler : Singleton<AudioControler>
{
    public AudioSource Music;
    public AudioSource EffectSound;
    [SerializeField] List<AudioClip> Album = new List<AudioClip>();

    public void SetEffectVoice(string filename)
    {
        EffectSound.clip = (AudioClip)Resources.Load("Sound/" + filename);
        if (EffectSound.clip != null)
        {
            EffectSound.Play();
        }
    }
    public void SetMusicStage(int stage)
    {
        Music.clip = Album[stage];
        if(Music.clip != null)
        {
            Music.Play();
        }
    }
}
