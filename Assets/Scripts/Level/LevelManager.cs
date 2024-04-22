using UnityEngine;
using UnityEngine.SceneManagement;
namespace Level {
    public class LevelManager : MonoBehaviour
    {
    
            [SerializeField] private GameObject _miniMapCameraPrefab;
            private void Start()
            {
                Instantiate(_miniMapCameraPrefab);
                SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
            }
        }
    }
    

