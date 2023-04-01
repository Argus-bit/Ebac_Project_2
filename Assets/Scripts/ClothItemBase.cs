using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemBase : MonoBehaviour
    {
        public SFXType sfxType;
        public int presentCloth;
        public float duration = 2f;
        public string compareTag = "Player";
        internal static object Instance;
        private SaveSetup _saveSetup;
        private SaveManager _saveManager;
        public ClothType clothType;

        public void Start()
        {
            LoadItemsFromSave();
        }
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
               // _saveSetup.cloth = ClothManager.Instance.GetSetupType(clothType);
               // _saveManager.Save();

            }
        }
        public virtual void Collect()
        {
            PlayeSFX();
            var setup = ClothManager.Instance.GetSetupType(clothType);
            Player.Instance.ChangeTexture(setup, duration);
            SaveManager.Instance.SaveCloth(setup);
            Debug.Log(clothType);
            HideObject();
        }

        private void PlayeSFX()
        {
            SFXPool.Instance.Play(sfxType);
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
        private void LoadItemsFromSave()
        {
            var setup = SaveManager.Instance.Setup.cloth;
            Player.Instance.ChangeTexture(setup, duration);
        }

    }
}

