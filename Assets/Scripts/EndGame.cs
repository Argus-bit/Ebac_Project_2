using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObjects;
    public GameObject gameObject;
    private bool _endGame = false;
    private int currentLevel = 1;
    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(true);
        Player p = other.transform.GetComponent<Player>();
        if(!_endGame && p != null)
        {
            ShowEndGame();
        }
    }
    private void ShowEndGame()
    {
        _endGame = true;
        endGameObjects.ForEach(i =>i.SetActive(true));
        foreach(var i in endGameObjects)
        {
            i.SetActive(false);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(currentLevel);
        }
    }
}
