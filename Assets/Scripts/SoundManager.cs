using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class SoundManager
{
    public enum Sound
    {
        Jump,
        Die,
        CoinColl,
    }  

    public static void PlaySound(Sound sound){
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
        
    }

    public static AudioClip GetAudioClip(Sound sound){
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if(soundAudioClip.sound == sound){
                return soundAudioClip.audioClip;
            }
        }
        Debug.Log("Error");
        return null;
    }
}
