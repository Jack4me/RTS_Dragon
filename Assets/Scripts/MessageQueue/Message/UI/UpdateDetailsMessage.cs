using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace MessageQueue.Message.UI {
    public class UpdateDetailsMessage : IMessage {
        public List<UnitComponent> Units;
        public GameObject Model;
    }
}