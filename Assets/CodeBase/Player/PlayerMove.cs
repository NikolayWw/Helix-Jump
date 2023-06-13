using CodeBase.Logic;
using CodeBase.Services.StaticData;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ConstantForce _constantForce;

        private IStaticDataService _dataService;

        public void Construct(IStaticDataService dataService)
        {
            _dataService = dataService;
            SetConstantForce(dataService);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out JumpTrigger _))
            {
                _rigidbody.velocity *= 0;
                _rigidbody.AddForce(Vector3.up * _dataService.PlayerStaticData.JumpForce, ForceMode.VelocityChange);
            }
        }

        private void SetConstantForce(IStaticDataService dataService) =>
            _constantForce.force = new Vector3(_constantForce.force.x, dataService.PlayerStaticData.ConstantForceY, _constantForce.force.z);
    }
}