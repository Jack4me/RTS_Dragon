using Character;
using Enemy;
using MessageQueue;
using Spawner.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Battle {
    public class DeadComponent : MonoBehaviour {
        private float _timeToLive = 5;
        private float _counter;

        public void Start() {
            UpdateObjective();
        }

        private void Update() {
            _counter += Time.deltaTime;
            if (_counter > _timeToLive) {
                RemoveComponents();
                ResetComponents();
                gameObject.SetActive(false);
                Destroy(this);
                return;
            }
        }

        private void UpdateObjective() {
            if (TryGetComponent<EnemyComponent>(out var enemy)) {
                MessageQueueManager.Instance.SendMessage(new EnemyKilledMessage { Type = enemy.Type });
            }
        }

        private void ResetComponents() {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        private void RemoveComponents() {
            BaseCharacter character = GetComponent<BaseCharacter>();
            Destroy(character);
            CollisionComponent collision = GetComponent<CollisionComponent>();
            Destroy(collision);
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            Destroy(navMeshAgent);
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Destroy(rigidbody);
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            Destroy(sphereCollider);
        }
    }
}