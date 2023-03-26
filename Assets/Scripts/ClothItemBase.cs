using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemBase : MonoBehaviour
    {
        public ClothType clothType;
        public int presentCloth;
        public float duration = 2f;
        public string compareTag = "Player";

        public void Start()
        {
            LoadItemsFromSave();
        }
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
        public virtual void Collect()
        {
            var setup = ClothManager.Instance.GetSetupType(clothType);
            Player.Instance.ChangeTexture(setup, duration);
            Debug.Log(clothType);
            HideObject();
        }
        private void LoadItemsFromSave()
        {
            var setup = SaveManager.Instance.Setup.cloth;
            Player.Instance.ChangeTexture(setup, duration);
        }
        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}

