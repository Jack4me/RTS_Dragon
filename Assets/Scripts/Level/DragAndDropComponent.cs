using UnityEngine;

namespace Level {
    public class DragAndDropComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private string _tag = "Building";
        private GameObject _selectedGameObject;
        private float _startPositionY;
        private float _positionYWhileMoving;
    }
}
