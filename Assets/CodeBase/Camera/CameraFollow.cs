using UnityEngine;

namespace CodeBase.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private Transform _target;

        private void LateUpdate()
        {
            if (_target && IsTargetBelowUs())
                UpdatePosition();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            UpdatePosition();
        }

        private bool IsTargetBelowUs() =>
            transform.position.y > _target.position.y + _offset.y;

        private void UpdatePosition() =>
            transform.position = _target.position + _offset;
    }
}