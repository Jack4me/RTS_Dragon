using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {
    [SerializeField] private float _borderSize = 50f;
    [SerializeField] private float _panSpeed = 10f;

    [SerializeField] private Vector2 _panLimit =
        new Vector2(30f, 35f);

    [SerializeField] private float _scrollSpeed = 1000f;

    [SerializeField] private Vector2 _scrollLimit =
        new Vector2(5f, 10f);

    private Vector3 _initialPosition = Vector3.zero;
    private Camera _camera = null;
    private void Start()
    {
        _initialPosition = transform.position;
        _camera = GetComponent<Camera>();
    }
    private void UpdateZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scroll = scroll * _scrollSpeed * Time.deltaTime;
        _camera.orthographicSize += scroll;
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize,
            _scrollLimit.x, _scrollLimit.y);
    }
}