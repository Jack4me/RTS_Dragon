using UnityEngine;

namespace MessageQueue.Message.UI {
    public class UpdateResourceMessage : IMessage
    {
        public int Amount;
        public ResourceType Type;
    }
}
    