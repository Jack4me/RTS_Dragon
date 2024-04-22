using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool {
    public class ObjectPoolComponent : MonoBehaviour {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolSize;
        [SerializeField] private bool _allowCreation;

        [SerializeField] private List<GameObject> _gameObjectsList
            = new List<GameObject>();

        private void Awake() {
            for (int i = 0; i < _poolSize; i++) {
                _gameObjectsList.Add(CreateItem(false));
            }
        }

        private GameObject CreateItem(bool active) {
            GameObject item = Instantiate(_prefab);
            item.transform.SetParent(transform);
            item.SetActive(active);
            return item;
        }
  // созадётся пул объектов, а потом в методе GetObject создаются ещё объекты
  // зачем ? разве не из пула нужно их брать ? 
  public GameObject GetObject() {
            foreach (GameObject item in _gameObjectsList) {
                if (!item.activeInHierarchy) {
                    item.SetActive(true);
                    return item;
                }
            }

            if (_allowCreation) {
                GameObject item = CreateItem(true);
                _gameObjectsList.Add(item);
                return item;
            }

            return null;
        }
    }
}