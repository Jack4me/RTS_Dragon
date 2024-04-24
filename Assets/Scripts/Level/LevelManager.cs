using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Level {
    public class LevelManager : MonoBehaviour
    {
    
            [SerializeField] private GameObject _miniMapCameraPrefab;
            [SerializeField] private GameObject _fog;
            public static LevelManager Instance { private set; get; }
            public List<GameObject> Units { private set; get; }
            private void Start()
            {
                Instantiate(_miniMapCameraPrefab);
                SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
            }
        }
    }
    

