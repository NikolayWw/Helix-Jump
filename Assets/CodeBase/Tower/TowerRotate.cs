using CodeBase.Services.Input;
using CodeBase.Services.StaticData;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerRotate : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private IInputService _inputService;
        private float _speed;

        public void Construct(IInputService inputService, IStaticDataService dataService)
        {
            _inputService = inputService;
            _speed = dataService.TowerStaticData.RotateSpeed;
        }

        private void FixedUpdate()
        {
            UpdateRotate();
        }

        private void UpdateRotate()
        {
            Quaternion rotation = transform.rotation;
            rotation.eulerAngles += _inputService.RotateAxis * _speed * Time.fixedDeltaTime * Vector3.up;
            _rigidbody.MoveRotation(rotation);
        }
    }
}