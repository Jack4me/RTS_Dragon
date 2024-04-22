using MessageQueue;
using MessageQueue.Message.Enemy;
using UnityEditor;
using UnityEngine;

namespace Editor.Debug {
    public class EnemyDebugger : MonoBehaviour {
        [MenuItem("Dragoncraft/Debug/Enemy/Spawn Orc")]
        private static void SpawnOrc() {
            MessageQueueManager.Instance.SendMessage(new BasicOrcSpawnMessage()
            {
                SpawnPoint = new Vector3(-6, 0, 0)
            });
        }

        [MenuItem("Dragoncraft/Debug/Enemy/Spawn Golem")]
        private static void SpawnGolem() {
            MessageQueueManager.Instance.SendMessage(new BasicGolemSpawnMessage()
            {
                SpawnPoint = new Vector3(6, 0, 0)
            });
        }

        [MenuItem("Dragoncraft/Debug/Enemy/Spawn Red Dragon")]
        private static void SpawnRedDragon() {
            MessageQueueManager.Instance.SendMessage(new RedDragonSpawnMessage()
            {
                SpawnPoint = new Vector3(0, 0, 6)
            });
        }
    }
}