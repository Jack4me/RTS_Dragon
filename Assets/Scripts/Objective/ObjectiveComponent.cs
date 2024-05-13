using System;
using System.Collections.Generic;
using System.Text;
using Enemy;
using Level;
using MessageQueue;
using MessageQueue.Message.UI;
using Spawner.Enemy;
using TMPro;
using UnityEngine;

namespace Objective {
    public class ObjectiveComponent : MonoBehaviour {
        [SerializeField] private TMP_Text _objectiveText;
        private Dictionary<ResourceType, int> _resourceCounter = new Dictionary<ResourceType, int>();
        private Dictionary<EnemyType, int> _enemyCounter = new Dictionary<EnemyType, int>();
        private ObjectiveData _objectiveData;
        private float _timeCounter;
        private bool _playerWin;

        private void Start() {
            _objectiveData = LevelManager.Instance.GetObjectiveData();
            _timeCounter = _objectiveData.TimeInSeconds;
        }

        private void Update() {
            if (_timeCounter > 0) {
                _timeCounter -= Time.deltaTime;
                UpdateObjectives();
                CheckGameOver();
            }
        }

        private void OnResourceUpdated(UpdateResourceMessage message) {
            if (message.Amount < 0) {
                return;
            }

            if (_resourceCounter.TryGetValue(message.Type, out int counter)) {
                _resourceCounter[message.Type] = counter + message.Amount;
            }
            else {
                _resourceCounter.Add(message.Type, message.Amount);
            }
        }

        private void OnEnemyKilled(EnemyKilledMessage message) {
            if (_enemyCounter.TryGetValue(message.Type, out int counter)) {
                _enemyCounter[message.Type] = counter + 1;
            }
            else {
                _enemyCounter.Add(message.Type, 1);
            }
        }

        private void UpdateObjectives() {
            StringBuilder objectives = new StringBuilder();
            objectives.Append($"{_objectiveData.Description}{Environment.NewLine}");
            objectives.Append(GetTimeObjectiveText(_timeCounter));
            foreach (EnemyObjective enemy in _objectiveData.Enemies) {
                objectives.Append(GetEnemyObjectiveText(enemy));
            }

            foreach (ResourceObjective resource in _objectiveData.Resources) {
                objectives.Append(GetResourceObjectiveText(resource));
            }

            _objectiveText.text = objectives.ToString();
        }

        private string GetTimeObjectiveText(float seconds) {
            if (seconds < 0) {
                return $"<color=red>Time left:" + $" 00:00{Environment.NewLine}</color>";
            }

            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"Time left: {time:mm\\:ss}{Environment.NewLine}";
        }

        private string GetEnemyObjectiveText(EnemyObjective enemy) {
            _enemyCounter.TryGetValue(enemy.Type, out int counter);
            if (counter >= enemy.Quantity) {
                return $"<color=green>Kill {enemy.Type}: " +
                       $"{enemy.Quantity}/{enemy.Quantity}" +
                       $"{Environment.NewLine}</color>";
            }

            return $"Kill {enemy.Type}: " + $"{counter}/{enemy.Quantity}{Environment.NewLine}";
        }

        private string GetResourceObjectiveText(ResourceObjective resource) {
            _resourceCounter.TryGetValue(resource.Type, out int counter);
            if (counter >= resource.Quantity) {
                return $"<color=green>Collect {resource.Type}: " +
                       $"{resource.Quantity}/{resource.Quantity}" +
                       $"{Environment.NewLine}</color>";
            }
            return $"Collect {resource.Type}: " + $"{counter}/{resource.Quantity}{Environment.NewLine}";
        }

        private void CheckGameOver() {
        }

        private void OnEnable() {
            MessageQueueManager.Instance.AddListener<EnemyKilledMessage>(OnEnemyKilled);
            MessageQueueManager.Instance.AddListener<UpdateResourceMessage>(OnResourceUpdated);
        }

        private void OnDisable() {
            MessageQueueManager.Instance.RemoveListener<EnemyKilledMessage>(OnEnemyKilled);
            MessageQueueManager.Instance.RemoveListener<UpdateResourceMessage>(OnResourceUpdated);
        }
    }
}