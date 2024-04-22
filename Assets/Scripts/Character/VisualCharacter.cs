using System;
using Battle;
using Configuration;
using Unit;
using UnityEngine;

namespace Character {
    [RequireComponent(typeof(Animator))]
    public sealed class VisualCharacter : MonoBehaviour {
        public Color SelectedColor;
        private Renderer _renderer;
        private Color _originalColor;
        private Color _emissionColor;
        private ActionType _action;

        private void Awake() {
            _renderer = GetComponentInChildren<Renderer>();
            _originalColor = _renderer.material.color;
            _emissionColor = _renderer.material.GetColor("_EmissionColor");
        }

        private void OnMouseEnter() {
            _renderer.material.color = SelectedColor;
        }

        private void OnMouseExit() {
            _renderer.material.color = _originalColor;
        }

        public void CopyBaseData(BaseCharacterData data) {
            SelectedColor = data.SelectedColor;
        }
    }
}