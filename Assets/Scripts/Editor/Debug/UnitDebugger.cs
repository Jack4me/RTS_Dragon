using MessageQueue;
using MessageQueue.Message.Unit;
using UnityEditor;

namespace Editor.Debug {
    public static class UnitDebugger {
        [MenuItem("Dragoncraft/Debug/Unit/Spawn Warrior %g")]
        private static void SpawnWarrior() {
            MessageQueueManager.Instance.SendMessage(new BasicWarriorSpawnMessage());
        }
        
        [MenuItem("Dragoncraft/Debug/Unit/Spawn Mage %h")]
        private static void SpawnMage()
        {
            MessageQueueManager.Instance.SendMessage(new BasicMageSpawnMessage());
        }
    }
}