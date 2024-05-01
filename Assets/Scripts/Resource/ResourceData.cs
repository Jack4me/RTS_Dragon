using UnityEngine;

namespace Resources {
    [CreateAssetMenu(menuName = "Dragoncraft/New Resource")]
    public class ResourceData : ScriptableObject
    {
        public int ProductionPerSecond;
        public int ProductionLevel;
        public ResourceType Type;
    }
}
