using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Itens
{
    public class ItemCollatableBase : MonoBehaviour
    {
        public ItemType itemType;
        public SFXType sfxType;

        public string compareTag = "Player";
        public ParticleSystem particleSystem;
        public float timeToHide = 3;
        public GameObject graphicItem;

        public Collider collider; 

        [Header("Sounds")]
        public AudioSource audioSource;

        private void Awake()
        {
          // if(GetComponent<ParticleSystem>() != null) GetComponent<ParticleSystem>().transform.SetParent(null);
          // if(audioSource != null) audioSource.transform.SetParent(null);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
        private void PlayeSFX()
        {
            SFXPool.Instance.Play(sfxType);
        }
        protected virtual void Collect()
        {
            PlayeSFX();
            if(collider != null) collider.enabled = false;
            if(graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
        }
        private void HideObject()
        {
           gameObject.SetActive(false);
        }
        protected virtual void OnCollect()
        {
            if (particleSystem != null) particleSystem.Play();
            if (audioSource != null) audioSource.Play();
            ItemManager.Instance.AddByType(itemType);
        }
    }
}