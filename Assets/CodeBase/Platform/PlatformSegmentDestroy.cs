using UnityEngine;

namespace CodeBase.Platform
{
    public class PlatformSegmentDestroy : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collisionCollider;

        public void Break(float explosionForce, Vector3 explosionPosition, float explosionRadius)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
            _collisionCollider.enabled = false;
        }
    }
}