using System.Collections.Generic;
using UnityEngine;

namespace Store {
    [CreateAssetMenu(menuName = "Dragoncraft/New Resource Store")]
    public class ResourceStoreData : ScriptableObject
    {
        public List<ResourceStoreItem> Items =
            new List<ResourceStoreItem>();
    }
}
