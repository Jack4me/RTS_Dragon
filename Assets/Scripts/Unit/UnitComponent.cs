using System;
using Character;
using Configuration;
using MessageQueue;
using MessageQueue.Message.Battle;
using MessageQueue.Message.UI;
using UnityEngine;

namespace Unit {
    public class UnitComponent : BaseCharacter {
        public UnitType Type;
        public int Level;
        public float LevelMultiplier;
        public ActionType Actions;
        private Vector3 _movePosition;
        private bool _shouldMove;
        private bool _shouldAttack;
        private float _attackCooldown;
        private UnitData _unitData;

        private float _minDistance = 0.5f;

        private const string IDLE = "Idle";
        //     public string ID;
        //     public UnitType Type;
        //     public int Level;
        //     public float LevelMultiplier;
        //     public float Health;
        //     public float Attack;
        //     public float Defense;
        //     public float WalkSpeed;
        //     public float AttackSpeed;
        //
        //     public Color OriginalColor;
        //     public float AttackRange;
        //     public ActionType Actions;
        //
        //     private bool _shouldAttack;
        //     private float _attackCooldown;
        //     private ActionType _action;
        //     private UnitData _unitData;
        //     private float _minDistance = 0.5f;
        //     public Color SelectedColor { get; set; }
        //
        //     private Animator _animator;
        //     private Renderer _renderer;
        //
        //     private Vector3 _movePosition;
        //     private bool _shouldMove;
        //

        //

        //
        //
        //     public void CopyData(UnitData unitData) {
        //         ID = Guid.NewGuid().ToString();
        //         Type = unitData.UnitType;
        //         Level = unitData.Level;
        //         LevelMultiplier = unitData.LevelMultiplier;
        //         Health = unitData.Health;
        //         Attack = unitData.Attack;
        //         Defense = unitData.Defense;
        //         WalkSpeed = unitData.WalkSpeed;
        //         AttackSpeed = unitData.AttackSpeed;
        //         SelectedColor = unitData.SelectedColor;
        //
        //         OriginalColor = unitData.OriginalColor;
        //         AttackRange = unitData.AttackRange;
        //         Actions = unitData.Actions;
        //         _unitData = unitData;
        //         EnableMovement(false);
        //     }
        //

        public void CopyData(UnitData unitData) {
            CopyBaseData(unitData);
            Type = unitData.UnitType;
            Level = unitData.Level;
            LevelMultiplier = unitData.LevelMultiplier;
            Actions = unitData.Actions;
            _unitData = unitData;
            _action = ActionType.Move;
            EnableMovement(false);
        }

        private void OnEnable() {
            MessageQueueManager.Instance.AddListener<ActionCommandMessage>(OnActionCommandReceived);
            MessageQueueManager.Instance.AddListener<UpgradeUnitMessage>(OnUnitUpgradeReceived);
        }

        private void OnUnitUpgradeReceived(UpgradeUnitMessage message) {
            if (Type == message.Type) {
                Level++;
            }
        }

        private void OnDisable() {
            MessageQueueManager.Instance.RemoveListener<ActionCommandMessage>(OnActionCommandReceived);
            MessageQueueManager.Instance.RemoveListener<UpgradeUnitMessage>(OnUnitUpgradeReceived);
        }

        private void Awake() {
            _renderer = GetComponentInChildren<Renderer>();
            _animator = GetComponent<Animator>();
            _animator.Play(IDLE);
        }

        private void Update() {
            switch (_action) {
                case ActionType.Attack:
                    UpdateAttack();
                    break;
                case ActionType.Defense:
                    UpdateDefense();
                    break;
                case ActionType.Move:
                    UpdateMovement();
                    break;
                case ActionType.Collect:
                    UpdateCollect();
                    break;
                case ActionType.Build:
                case ActionType.Upgrade:
                case ActionType.None:
                default:
                    EnableMovement(false);
                    break;
            }
        }

        public void Selected(bool selected) {
            if (_renderer == null) {
                Debug.LogError("Renderer component is missing!");
                return;
            }

            Material[] materials = _renderer.materials;
            foreach (Material material in materials) {
                if (selected) {
                    material.EnableKeyword("_EMISSION");
                    material.SetColor("_EmissionColor", SelectedColor * 0.5f);
                }
                else {
                    material.SetColor("_EmissionColor", _emissionColor);
                }
            }
        }


        protected override void UpdateState(ActionType action) {
            base.UpdateState(action);
            switch (action) {
                case ActionType.Attack:
                    EnableMovement(false);
                    UnitAnimationState attackState = (UnityEngine.Random.value < 0.5f)
                        ? UnitAnimationState.Attack01
                        : UnitAnimationState.Attack02;
                    PlayAnimation(attackState);
                    break;
                case ActionType.Move:
                    EnableMovement(true);
                    break;
                case ActionType.None:
                    _movePosition = transform.position;
                    break;
                default:
                    break;
            }
        }

        protected override void PlayAnimation(UnitAnimationState state) {
            _animator.Play(_unitData.GetAnimationState(state));
        }

        private void EnableMovement(bool enabledMove) {
            if (enabledMove) {
                _animator.Play(_unitData.GetAnimationState(UnitAnimationState.Move));
            }
            else {
                _animator.Play(_unitData.GetAnimationState(UnitAnimationState.Idle));
            }

            _shouldMove = enabledMove;
        }

        public void MoveTo(Vector3 position) {
            transform.LookAt(position);
            _movePosition = position;
            _animator.Play("Run");
            _shouldMove = true;
        }

        private void UpdateAttack() {
            UnitAnimationState attackState =
                (UnityEngine.Random.value < 0.5f) ? UnitAnimationState.Attack01 : UnitAnimationState.Attack02;
            UpdatePosition(_minDistance + AttackRange, attackState);
            if (!_shouldAttack || AttackRange <= 0) {
                return;
            }

            _attackCooldown -= Time.deltaTime;
            if (_attackCooldown < 0) {
                MessageQueueManager.Instance.SendMessage(new FireballSpawnMessage
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    Damage = Attack
                });
                _attackCooldown = AttackSpeed;
            }
        }

        private void UpdateDefense() {
            UpdatePosition(_minDistance, UnitAnimationState.Defense);
        }

        private void UpdateMovement() {
            UpdatePosition(_minDistance, UnitAnimationState.Idle);
        }

        private void UpdateCollect() {
            UpdatePosition(_minDistance, UnitAnimationState.Collect);
        }

        private void UpdatePosition(float range, UnitAnimationState state) {
            if (!_shouldMove) {
                return;
            }

            if (Vector3.Distance(transform.position, _movePosition) < range) {
                _animator.Play(_unitData.GetAnimationState(state));
                _shouldMove = false;
                _shouldAttack = true;
                return;
            }

            UpdatePosition();
        }

        protected virtual void UpdatePosition() {
            Vector3 direction =
                (_movePosition - transform.position).normalized;
            transform.position += direction * Time.deltaTime * WalkSpeed;
        }

        protected Vector3 GetFinalPosition() {
            return _movePosition;
        }

        protected virtual void OnCollisionEnter(Collision collision) {
            if (!collision.gameObject.CompareTag("Plane")) {
                _animator.Play(_unitData.GetAnimationState(UnitAnimationState.Idle));
                _shouldMove = false;
            }
        }

        private void OnActionCommandReceived(ActionCommandMessage message) {
            _action = message.Action;
            _shouldAttack = false;
        }

        protected virtual void StopMovingAndAttack() {
            _shouldMove = false;
            _shouldAttack = true;
        }
    }
}