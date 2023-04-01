using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public SFXType sfxType;
    public MeshRenderer meshRenderer;
    public int key = 01;
    private string checkPointKey = "CheckPointKey";
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        { CheckCheckPoint();
          PlayeSFX();
        }
    }
    private void PlayeSFX()
    {
        SFXPool.Instance.Play(sfxType);
    }
    [NaughtyAttributes.Button]
    private void CheckCheckPoint()
    {
        SaveCheckpoint();
        TurnItOn();
    }

    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.blue);
        Debug.Log("Change Color");

    }
    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }
    private void SaveCheckpoint()
    {
        /*if(PlayerPrefs.GetInt(checkPointKey,0) > key)
        PlayerPrefs.SetInt(checkPointKey, key);*/
        CheckpointManager.Instance.SaveCheckPoint(key);
    }
}
