using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;

namespace Cloth
{
    public enum ClothType
    {
        SPEED,
        STRONG,
        TURTLE
    }
    public class ClothManager : Singleton<ClothManager>
    {
        public int lastCloth = 0;

        public List<ClothSetup> clothSetups;

        public ClothSetup GetSetupType(ClothType clothType)
        {
            return clothSetups.Find(i => i.clothType == clothType);
        }
    }
    [System.Serializable]
    public class ClothSetup
    {
        public ClothType clothType;
        public Texture2D texture;
    }
}
