using UnityEngine;
using UnityEngine.EventSystems;

namespace Level {
    public class DragAndDropComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private string _tag = "Building";
        private GameObject _selectedGameObject;
        private float _startPositionY;
        private float _positionYWhileMoving;

        private void Update() {
        }
        // {
        //     if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        //     {
        //         return;
        //     }
        //     if (Input.GetKeyDown(KeyCode.Mouse0))
        //     {
        //         if (_selectedGameObject == null)
        //         {
        //             StartDragging();
        //         }
        //         else
        //         {
        //             StopDragging();
        //         }
        //     }
        //     if (_selectedGameObject != null)
        //     {
        //         DragObject();
        //     }
        // }
    }
}
