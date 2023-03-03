using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChesItemCoin : MonoBehaviour
{
    public int coinNumber = 5;
    public GameObject coinObject;
    
    private List<GameObject> _itens = new List<GameObject>();

    /*public override void ShowItem()
    {
        //base.ShowItem();
        CreateItens();
    }*/
    private void CreateItens()
    {
        for (int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position;
            item.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            _itens.Add(item);
        }
    }
}
