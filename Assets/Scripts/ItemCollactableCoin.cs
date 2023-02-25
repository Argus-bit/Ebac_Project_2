using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemCollactableCoin : ItemCollatableBase
{
    public Collider collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider.enabled = false;
    }
}
