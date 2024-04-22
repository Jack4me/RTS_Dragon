using UnityEngine;

namespace MessageQueue.Message.Battle {
    public class FireballSpawnMessage : IMessage {
        public Vector3 Position;
        public Quaternion Rotation;
        public float Damage;
    }
}

