using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckPointKey = 0;
    public List<CheckPointBase> checkpoints;


    private void Start()
    {
        LoadItemsFromSave();
    }

    private void LoadItemsFromSave()
    {
        lastCheckPointKey = SaveManager.Instance.Setup.checkpoint;
    }


    public bool HasCkeckpoint()
    {
        return lastCheckPointKey > 0;
    }
    public void SaveCheckPoint(int i)
    {
        if(i > lastCheckPointKey)
        {
            lastCheckPointKey = i;
        }
    }
    public Vector3 GetPositionFromLastCheckpoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckPointKey);
        return checkpoint.transform.position;
    }
}
