using System;
using Configuration;
using Configuration.LevelConfigurations.Data;
using Enemy;
using MessageQueue;
using MessageQueue.Message.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Level {
    public class LevelComponent : MonoBehaviour {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private GameObject _plane;

        public delegate void Delegat();

        private float _distanceBetweenEnemies = 3.0f;

        private void Awake() {
            Delegat d = delegate { Debug.Log("DELEGAGE"); };
            DelegatMethod(d);
        }

        public void DelegatMethod(Delegat deleg) {
            deleg();
        }

        private void Start() {
            if (_levelData == null || _plane == null) {
                Debug.LogError("Missing LevelData or Plane");
                return;
            }

            Collider planeCollider = _plane.GetComponent<Collider>();
            Vector3 planeSize = planeCollider.bounds.size;
            Vector3 startPosition = new Vector3(-planeSize.x / 2, 0,
                planeSize.z / 2);
            float offsetX = planeSize.x / _levelData.Columns - 1;
            Debug.Log(startPosition);
            float offsetZ = planeSize.z / _levelData.Rows - 1;

            Initialize(startPosition, offsetX, offsetZ);
            SpawnEnemyGroups();
        }

        private void SpawnEnemyGroups() {
            foreach (EnemyGroupConfiguration group in _levelData.EnemyGroups) {
                SpawnEnemyGroup(group);
            }
        }

        private void SpawnEnemyGroup(EnemyGroupConfiguration enemyGroup) {
            int rows = Mathf.RoundToInt(Mathf.Sqrt(enemyGroup.Data.Enemies.Count));
            int counter = 0;
            for (int i = 0; i < enemyGroup.Data.Enemies.Count; i++) {
                if (i > 0 && (i % rows) == 0) {
                    counter++;
                }

                float offsetX = (i % rows) * _distanceBetweenEnemies;
                float offsetZ = counter * _distanceBetweenEnemies;
                Vector3 offset = new Vector3(offsetX, 0, offsetZ);
                Vector3 spawnPoint = enemyGroup.Position + offset;
                SpawnEnemy(enemyGroup.Data.Enemies[i].Type, spawnPoint);
            }
        }

        private void SpawnEnemy(EnemyType enemyType, Vector3 spawnPoint) {
            switch (enemyType) {
                case EnemyType.Orc:
                    MessageQueueManager.Instance.SendMessage(new BasicOrcSpawnMessage
                        {
                            SpawnPoint = spawnPoint
                        });
                    break;
                case EnemyType.Golem:
                    MessageQueueManager.Instance.SendMessage(new BasicGolemSpawnMessage
                        {
                            SpawnPoint = spawnPoint
                        });
                    break;
                case EnemyType.Dragon:
                    MessageQueueManager.Instance.SendMessage(new RedDragonSpawnMessage
                        {
                            SpawnPoint = spawnPoint
                        });
                    break;
                default:
                    break;
            }
        }

        private void Initialize(Vector3 start, float offsetX, float offsetZ) {
            foreach (LevelSlot slot in _levelData.Slots) {
                LevelItem levelItem =
                    _levelData.Configuration.FindByType(slot.ItemType);
                if (levelItem == null) {
                    continue;
                }

                float coordinatesY = slot.Coordinates.y * offsetX;
                float x = start.x + coordinatesY +
                          offsetX / 2;
                float z = start.z - (slot.Coordinates.x * offsetZ) -
                          offsetZ / 2;
                Vector3 position = new Vector3(x, 0, z);
                Instantiate(levelItem.Prefab, position, Quaternion.identity,
                    transform);
                GameObject item = Instantiate(levelItem.Prefab,
                    position, Quaternion.identity, transform);
                switch (levelItem.CollistionType) {
                    case LevelItemCollistionType.Rigidbody:
                        item.AddComponent<BoxCollider>();
                        break;
                    case LevelItemCollistionType.NavMesh:
                        item.AddComponent<NavMeshObstacle>();
                        break;
                    case LevelItemCollistionType.None:
                    default:
                        break;
                }
            }
        }
    }
}