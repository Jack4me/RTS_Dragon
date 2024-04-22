using Battle;
using Configuration;
using UnityEngine;
using UnityEngine.AI;

namespace Unit {
    [RequireComponent(typeof(NavMeshAgent), typeof(CollisionComponent))]
    public class UnitComponentNavMesh : UnitComponent {
        private NavMeshAgent _agent;
        private CollisionComponent _collisionComponent;

        private void Start() {
            _collisionComponent = GetComponent<CollisionComponent>();
            _collisionComponent.Initialize(this);
            _collisionComponent.OnStartAttacking += OnStartAttacking;
            _collisionComponent.OnStopAttacking += OnStopAttacking;
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = WalkSpeed;
        }

        private void OnStartAttacking(Transform target) {
            transform.LookAt(target.position);
            _agent.isStopped = true;
            UpdateState(ActionType.Attack);
        }

        private void OnStopAttacking(Transform target, bool opponentIsDead) {
            if (IsDead) {
                return;
            }

            UpdateState(ActionType.None);
        }

        protected override void OnCollisionEnter(Collision collision) {
            base.OnCollisionEnter(collision);
            if (!collision.gameObject.CompareTag("Plane")) {
                _agent.isStopped = true;
            }
        }

        protected override void UpdatePosition() {
            _agent.isStopped = false;
            _agent.destination = GetFinalPosition();
        }

        protected override void StopMovingAndAttack() {
            base.StopMovingAndAttack();
            _agent.isStopped = true;
        }

        private void OnDestroy() {
            if (_collisionComponent != null) {
                _collisionComponent.OnStartAttacking -= OnStartAttacking;
                _collisionComponent.OnStopAttacking -= OnStopAttacking;
            }
        }
    }
}