using UnityEngine;

namespace CodeBase.StaticData.Platform
{
    [CreateAssetMenu(menuName = "Static Data/Platform Static Data")]
    public class PlatformStaticData : ScriptableObject
    {
        [field: SerializeField] public float ExplosionForce { get; private set; } = 100f;
        [field: SerializeField] public float ExplosionRadius { get; private set; } = 1f;
        [field: SerializeField] public float LifetimeAfterDestruction { get; private set; } = 1f;

        private void OnValidate()
        {
            if (LifetimeAfterDestruction < 0)
                LifetimeAfterDestruction = 0;
        }
    }
}