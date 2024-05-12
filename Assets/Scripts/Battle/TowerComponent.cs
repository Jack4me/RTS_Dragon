using System.Collections.Generic;
using MessageQueue;
using MessageQueue.Message.Battle;
using UnityEngine;

namespace Battle {
    public class TowerComponent : MonoBehaviour {
        [SerializeField] private float _attack = 1;
        [SerializeField] private float _cooldown = 3;
        private List<GameObject> _targets = new List<GameObject>();
        private float _cooldownCounter;

        private void Update() {
            if (_targets.Count == 0) {
                return;
            }

            _cooldownCounter -= Time.deltaTime;
            if (_cooldownCounter < 0) {
                transform.LookAt(
                    _targets[_targets.Count - 1].transform.position);
                MessageQueueManager.Instance.SendMessage(
                    new FireballSpawnMessage
                    {
                        Position = transform.position,
                        Rotation = transform.rotation,
                        Damage = _attack,
                        IsTower = true
                    });
                _cooldownCounter = _cooldown;
            }
        }

        private void OnCollisionEnter(Collision collision) {
            _targets.Add(collision.gameObject);
        }

        private void OnCollisionExit(Collision collision) {
            _targets.Remove(collision.gameObject);
        }
    }
}