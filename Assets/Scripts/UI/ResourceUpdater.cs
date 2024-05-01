using Level;
using MessageQueue;
using MessageQueue.Message.UI;
using TMPro;
using UnityEngine;

namespace UI {
    public class ResourceUpdater : MonoBehaviour {
        [SerializeField] private ResourceType _type;
        [SerializeField] private TMP_Text _value;
        private int _currentValue;

        private void Awake() {
            if (_value == null) {
                Debug.LogError("Missing TMP_Text variable in the script");
                return;
            }

            UpdateValue();
        }

        private void OnEnable() {
            MessageQueueManager.Instance.AddListener<UpdateResourceMessage>(OnResourceUpdated);
        }


        private void OnDisable() {
            MessageQueueManager.Instance.RemoveListener<UpdateResourceMessage>(OnResourceUpdated);
        }

        private void OnResourceUpdated(UpdateResourceMessage message) {
            if (_type == message.Type) {
                LevelManager.Instance.UpdateResource(_type, message.Amount);
                UpdateValue();
            }
        }

        private void UpdateValue() {
            _value.text = $"{_type}: {LevelManager.Instance.GetResource(_type)}";
        }
    }
}