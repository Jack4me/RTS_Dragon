using MessageQueue;
using MessageQueue.Message.UI;
using UnityEditor;
using UnityEngine;

namespace Editor.Debug {
    public static class ResourceDebugger {
        [MenuItem("Dragoncraft/Debug/Resources/+10000 Gold", priority = 0)]
        private static void AddGold() {
            MessageQueueManager.Instance.SendMessage(new UpdateResourceMessage
            {
                Type = ResourceType.Gold,
                Amount = 10000,
            });
        }

        [MenuItem("Dragoncraft/Debug/Resources/-1000 Gold", priority = 1)]
        private static void SubtractGold() {
            MessageQueueManager.Instance.SendMessage(
                new UpdateResourceMessage
                {
                    Type = ResourceType.Gold,
                    Amount = -1000
                });
        }

        [MenuItem("Dragoncraft/Debug/Resources/+10000 Wood", priority = 3)]
        private static void AddWood() {
            MessageQueueManager.Instance.SendMessage(
                new UpdateResourceMessage
                {
                    Type = ResourceType.Wood,
                    Amount = 10000
                });
        }

        [MenuItem("Dragoncraft/Debug/Resources/+10000 Food", priority = 4)]
        private static void AddFood() {
            MessageQueueManager.Instance.SendMessage(
                new UpdateResourceMessage
                {
                    Type = ResourceType.Food,
                    Amount = 10000
                });
        }
    }
}