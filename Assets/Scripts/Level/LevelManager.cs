using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level {
    public class LevelManager : MonoBehaviour {
        [SerializeField] private GameObject _miniMapCameraPrefab;
        [SerializeField] private GameObject _fog;
        private InventoryManager _inventory;
        public static LevelManager Instance { private set; get; }
        public List<GameObject> Units { private set; get; }

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);  
                return;
            }

            Instance = this;
            Units = new List<GameObject>();
            _inventory = new InventoryManager();
        }

        private void Start() {
            Instantiate(_miniMapCameraPrefab);
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
            _fog.SetActive(true);
        }

        private void OnDestroy() {
            _inventory.Dispose();
        }

        public void UpdateResource(ResourceType type, int amount) {
            _inventory.UpdateResource(type, amount);
        }

        public int GetResource(ResourceType type) {
            return _inventory.GetResource(type);
        }
    }
}