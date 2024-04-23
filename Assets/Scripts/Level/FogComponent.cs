using UnityEngine;

namespace Level {
    public class FogComponent : MonoBehaviour
    {
        [SerializeField] private float _radius = 7;
        [SerializeField] private float _initialArea = 14;
        [SerializeField] private LayerMask _layerMask;
        private Mesh _mesh;
        private Vector3[] _vertices;
        private Color[] _colors;
    }
}
