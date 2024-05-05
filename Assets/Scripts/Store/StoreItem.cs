using System;
using UnityEngine;

namespace Store {
    [Serializable]
    public class StoreItem {
        public string Description;
        public int PriceGold;
        public int PriceResource;
        public ResourceType CurrencyResource;
        public GameObject Prefab;
        public Sprite Image;
    }
}