using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetup;

    public AudioSource musicSource;
    
    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSetups.Add(music);
    }
    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }
    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetup.Find(i => i.sfxType == sfxType);
    }
}
public enum MusicType
{
    TYPE_01,
    TYPE_02,
    TYPE_03
}
[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}
public enum SFXType
{
    NONE,
    TYPE_01,
    TYPE_02,
    TYPE_03
}
[System.Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip audioClip;
}
