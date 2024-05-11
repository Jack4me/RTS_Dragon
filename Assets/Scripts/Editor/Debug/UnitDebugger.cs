using MessageQueue;
using MessageQueue.Message.UI;
using MessageQueue.Message.Unit;
using Unit;
using UnityEditor;

namespace Editor.Debug {
    public static class UnitDebugger {
        [MenuItem("Dragoncraft/Debug/Unit/Spawn Warrior %g")]
        private static void SpawnWarrior() {
            MessageQueueManager.Instance.SendMessage(new BasicWarriorSpawnMessage());
        }

        [MenuItem("Dragoncraft/Debug/Unit/Spawn Mage %h")]
        private static void SpawnMage() {
            MessageQueueManager.Instance.SendMessage(new BasicMageSpawnMessage());
        }

        [MenuItem("Dragoncraft/Debug/Unit/Upgrade Warrior")]
        private static void UpgradeWarrior() {
            MessageQueueManager.Instance.SendMessage(new UpgradeUnitMessage { Type = UnitType.Warrior });
        }

        [MenuItem("Dragoncraft/Debug/Unit/Upgrade Mage")]
        private static void UpgradeMage() {
            MessageQueueManager.Instance.SendMessage(new UpgradeUnitMessage { Type = UnitType.Mage });
        }
    }
}