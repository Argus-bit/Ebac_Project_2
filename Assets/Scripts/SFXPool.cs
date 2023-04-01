using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;

public class SFXPool : Singleton<SFXPool>
{
    private List<AudioSource> _audioSourceList;
    public int poolSize = 10;
    private int index = 0;

    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();
        for(int i = 0; i < poolSize; i++)
        { CreateAudioSourceItem(); }
    }
    private void CreateAudioSourceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);
        _audioSourceList.Add(go.AddComponent<AudioSource>());
    }
    public void Play(SFXType sfxType)
    {
        if (sfxType == SFXType.NONE) return;
        var sfx = SoundManager.Instance.GetSFXByType(sfxType);
        _audioSourceList[index].clip = sfx.audioClip;
        _audioSourceList[index].Play();
        index++;
        if (index >= _audioSourceList.Count) index = 0;
    }
}