using System;
using Extension;
using Level;
using MessageQueue;
using MessageQueue.Message.Unit;
using Unit;
using UnityEngine;

namespace Spawner {
    public class BasicWarriorSpawner : BaseSpawner {
        [SerializeField] private UnitData _unitData;

        private void OnEnable() {
            MessageQueueManager.Instance.AddListener<BasicWarriorSpawnMessage>(OnBasicWarriorSpawned);
        }

        private void OnDisable() {
            MessageQueueManager.Instance.RemoveListener<BasicWarriorSpawnMessage>(OnBasicWarriorSpawned);
        }

        private void OnBasicWarriorSpawned(BasicWarriorSpawnMessage message) {
            // GameObject warrior = SpawnObject();
            // UnitComponent unit = warrior.GetComponent<UnitComponent>();
            // if (unit == null) {
            //     unit = warrior.AddComponent<UnitComponent>();
            // }
            //
            // unit.ID = Guid.NewGuid().ToString();
            // unit.Type = _unitData.UnitType;
            // unit.Level = _unitData.Level;
            // unit.LevelMultiplier = _unitData.LevelMultiplier;
            // unit.Health = _unitData.Health;
            // unit.Attack = _unitData.Attack;
            // unit.Defense = _unitData.Defense;
            // unit.WalkSpeed = _unitData.WalkSpeed;
            // unit.AttackSpeed = _unitData.AttackSpeed;
            GameObject warrior = SpawnObject();
            warrior.SetLayerMaskToAllChildren("Unit");
            UnitComponentNavMesh unitComponent = warrior.GetComponent<UnitComponentNavMesh>();
            if (unitComponent == null)
            {
                unitComponent = warrior.AddComponent<UnitComponentNavMesh>();
            }
            
            unitComponent.CopyData(_unitData);
            LevelManager.Instance.Units.Add(warrior);
        }
    }
}