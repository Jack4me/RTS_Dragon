using Battle;
using Enemy;
using Extension;
using MessageQueue;
using MessageQueue.Message;
using MessageQueue.Message.Enemy;
using UnityEngine;
using RedDragonSpawnMessage = MessageQueue.Message.Enemy.RedDragonSpawnMessage;

namespace Spawner.Enemy {
    public class EnemySpawner : BaseSpawner {
        [SerializeField] private EnemyData _enemyData;

        private void OnEnable() {
            switch (_enemyData.Type) {
                case EnemyType.Orc:
                    MessageQueueManager.Instance.AddListener<BasicOrcSpawnMessage>(OnEnemySpawned);
                    break;
                case EnemyType.Golem:
                    MessageQueueManager.Instance.AddListener<BasicGolemSpawnMessage>(OnEnemySpawned);
                    break;
                case EnemyType.Dragon:
                    MessageQueueManager.Instance.AddListener<RedDragonSpawnMessage>(OnEnemySpawned);
                    break;
                default:
                    break;
            }
        }

        private void OnDisable() {
            switch (_enemyData.Type) {
                case EnemyType.Orc:
                    MessageQueueManager.Instance.RemoveListener<BasicOrcSpawnMessage>(OnEnemySpawned);
                    break;
                case EnemyType.Golem:
                    MessageQueueManager.Instance.RemoveListener<BasicGolemSpawnMessage>(OnEnemySpawned);
                    break;
                case EnemyType.Dragon:
                    MessageQueueManager.Instance.RemoveListener<RedDragonSpawnMessage>(OnEnemySpawned);
                    break;
                default:
                    break;
            }
        }

        private void OnEnemySpawned(BaseEnemySpawnMessage message) {
            GameObject enemyObject = SpawnObject();
            enemyObject.SetLayerMaskToAllChildren("Enemy");
            EnemyComponentNavMesh enemyComponent = enemyObject.GetComponent<EnemyComponentNavMesh>();
            if (enemyComponent == null) {
                enemyComponent = enemyObject.AddComponent<EnemyComponentNavMesh>();
            }
            enemyComponent.CopyData(_enemyData, message.SpawnPoint);
        }
    }
}