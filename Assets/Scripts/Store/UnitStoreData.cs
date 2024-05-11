using System.Collections.Generic;
using UnityEngine;

namespace Store {
    [CreateAssetMenu(menuName = "Dragoncraft/New Unit Store")]
    public class UnitStoreData : ScriptableObject
    {
        public List<UnitStoreItem> Items = new List<UnitStoreItem>();
    }
}
