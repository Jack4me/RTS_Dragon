using ObjectPool;
using UnityEngine;

namespace Spawner {
    [RequireComponent(typeof(ObjectPoolComponent))]
    public class BaseSpawner : MonoBehaviour {
        private ObjectPoolComponent _objectPoolComponent;

        private void Awake() {
            _objectPoolComponent =
                GetComponent<ObjectPoolComponent>();
        }

        public GameObject SpawnObject() {
            return _objectPoolComponent.GetObject();
        }
    }
}