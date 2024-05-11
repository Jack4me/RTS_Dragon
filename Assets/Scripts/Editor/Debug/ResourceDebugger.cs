using MessageQueue;
using MessageQueue.Message.UI;
using UnityEditor;
using UnityEngine;

namespace Editor.Debug {
    public static class ResourceDebugger {
        [MenuItem("Dragoncraft/Debug/Resources/+10 Gold", priority = 0)]
        private static void AddGold() {
            MessageQueueManager.Instance.SendMessage(new UpdateResourceMessage
            { 
                    Type = ResourceType.Gold,
                    Amount = 10,
                    
                });
        }

        [MenuItem("Dragoncraft/Debug/Resources/-10 Gold", priority = 1)]
        private static void SubtractGold() {
            MessageQueueManager.Instance.SendMessage(
                new UpdateResourceMessage
                {
                    Type = ResourceType.Gold,
                    Amount = -10
                });
        }
        
        [MenuItem("Dragoncraft/Debug/Resources/+100 Wood", priority = 3)]
        private static void AddWood() {
            MessageQueueManager.Instance.SendMessage(
                new UpdateResourceMessage
                {
                    Type = ResourceType.Wood,
                    Amount = 100
                });
        }
    }
}

