using System.Collections.Generic;
using Inventory;
using Objective;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Level {
    public class LevelManager : MonoBehaviour {
        [SerializeField] private GameObject _miniMapCameraPrefab;
        [SerializeField] private GameObject _fog;
        private InventoryManager _inventory;
        public static LevelManager Instance { private set; get; }
        public List<GameObject> Units { private set; get; }
        [SerializeField] private ObjectiveData _objectiveData;
        
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);  
                return;
            }

            Instance = this;
            Units = new List<GameObject>();
            _inventory = new InventoryManager();
            _inventory.UpdateResource(ResourceType.Gold, 100);
        }

        private void Start() {
            Instantiate(_miniMapCameraPrefab);
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
            _fog.SetActive(true);
        }
        public ObjectiveData GetObjectiveData()
        {
            return _objectiveData;
        }
        public void AddTower(GameObject prefab)
        {
            Instantiate(prefab);
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
        public void AddBuilding(GameObject prefab)
        {
            GameObject building = Instantiate(prefab);
            building.AddComponent<MeshCollider>();
            building.AddComponent<NavMeshObstacle>();
            building.transform.localScale = Vector3.one * 0.5f;
            building.layer = LayerMask.NameToLayer("Resource");
            building.tag = "Building";
        }
    }
}