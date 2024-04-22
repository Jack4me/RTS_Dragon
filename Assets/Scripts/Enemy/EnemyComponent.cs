using Character;
using Configuration;
using Unit;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(BoxCollider), typeof(Animator))]
    public class EnemyComponent : BaseCharacter {
        // public string ID;
        // public EnemyType Type;
        // public float Health;
        // public float Attack;
        // public float Defense;
        // public float WalkSpeed;
        // public float AttackSpeed;
        // public Color SelectedColor;
        // private Animator _animator;
        // private Renderer _renderer;
        // private Color _originalColor;
        // private EnemyData _enemyData;
        //
        // private void Awake() {
        //     _animator = GetComponent<Animator>();
        //     _renderer = GetComponentInChildren<Renderer>();
        //     _originalColor = _renderer.material.color;
        // }
        //
       
        //
        // private void OnMouseEnter() {
        //     _renderer.material.color = SelectedColor;
        // }
        //
        // private void OnMouseExit() {
        //     _renderer.material.color = _originalColor;
        // }
        //
        // public void Selected() {
        //     TakeDamage(Attack);
        // }
        //
        // private void TakeDamage(float attack) {
        //     if (Health <= 0) {
        //         return;
        //     }
        //
        //     float damage = attack - Defense;
        //     if (damage > 0) {
        //         Health -= damage;
        //         // The offset is 1/4 of the model size
        //         Vector3 position = transform.position + (_renderer.bounds.size * 0.25f);
        //         MessageQueueManager.Instance.SendMessage(new DamageFeedbackMessage()
        //         {
        //             Damage = damage, Position = position
        //         });
        //     }
        //
        //     if (Health <= 0) {
        //         _animator.Play(_enemyData.GetAnimationState(UnitAnimationState.Death));
        //     }
        // // public void CopyData(EnemyData enemyData, Vector3 spawnPoint) {
                        //     ID = Guid.NewGuid().ToString();
                        //     Type = enemyData.Type;
                        //     Health = enemyData.Health;
                        //     Attack = enemyData.Attack;
                        //     Defense = enemyData.Defense;
                        //     WalkSpeed = enemyData.WalkSpeed;
                        //     AttackSpeed = enemyData.AttackSpeed;
                        //     SelectedColor = enemyData.SelectedColor;
                        //     _enemyData = enemyData;
                        //     transform.position = spawnPoint;
                        //     _animator.Play(_enemyData.GetAnimationState(UnitAnimationState.Idle));
                        // }
        // }

        public EnemyType Type;
        private EnemyData _enemyData;

        public void CopyData(EnemyData enemyData, Vector3 spawnPoint) {
            CopyBaseData(enemyData);
            Type = enemyData.Type;
            _enemyData = enemyData;
            _action = ActionType.None;
            transform.position = spawnPoint;
            PlayAnimation(UnitAnimationState.Idle);
        }

        protected override void UpdateState(ActionType action) {
            base.UpdateState(action);
            switch (action) {
                case ActionType.Attack: 
                    UnitAnimationState attackState = 
                        (UnityEngine.Random.value < 0.5f) ? UnitAnimationState.Attack01 : UnitAnimationState.Attack02;
                    PlayAnimation(attackState);
                    break;
                case ActionType.Move: PlayAnimation(UnitAnimationState.Move);
                    break;
                case ActionType.None: PlayAnimation(UnitAnimationState.Idle);
                    break;
                default:
                    break;
            }
        }

        protected override void PlayAnimation(UnitAnimationState state) {
            _animator.Play(_enemyData.GetAnimationState(state));
        }
    }
}