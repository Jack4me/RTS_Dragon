using UnityEngine;

namespace MessageQueue.Message.UI {
    public class DamageFeedbackMessage : IMessage {
        public float Damage;
        public Vector3 Position;
    }
}