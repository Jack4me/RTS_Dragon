using Configuration;
using UnityEngine;

namespace MessageQueue.Message.UI {
    public class ActionCommandMessage : IMessage
    {
        public ActionType Action;
    }
}
