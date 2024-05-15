using System;
using MessageQueue;
using MessageQueue.Message.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class GameOverComponent : MonoBehaviour {
        [SerializeField] private GameObject _gameOverPopup;
        [SerializeField] private TMP_Text _gameOverText;

        private void OnGameOver(GameOverMessage message) {
            _gameOverPopup.SetActive(true);
            if (message.PlayerWin) {
                _gameOverText.text = $"Game Over{Environment.NewLine}" + $"<color=green>You Win!</color>";
            }
            else {
                _gameOverText.text = $"Game Over{Environment.NewLine}" + $"<color=red>You Lose</color>";
            }
        }

        private void OnEnable() {
            MessageQueueManager.Instance.AddListener<GameOverMessage>(OnGameOver);
        }

        private void OnDisable() {
            MessageQueueManager.Instance.RemoveListener<GameOverMessage>(OnGameOver);
        }

        public void RestartLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}