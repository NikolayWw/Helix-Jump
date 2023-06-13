using CodeBase.Logic;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Platform;
using UnityEngine;

namespace CodeBase.Platform
{
    public class PlatformGroupBreak : MonoBehaviour
    {
        [SerializeField] private PlatformSegmentDestroy[] _segmentDestroy;
        [SerializeField] private PlayerTriggerReporter _playerTriggerReporter;
        private PlatformStaticData _config;

        public void Construct(IStaticDataService dataService)
        {
            _config = dataService.PlatformStaticData;
            _playerTriggerReporter.OnEnter += Explosion;
        }

        public void SetPlatformSegmentDestroy(PlatformSegmentDestroy[] segmentDestroys)
        {
            _segmentDestroy = segmentDestroys;
        }

        private void Explosion()
        {
            _playerTriggerReporter.OnEnter -= Explosion;

            foreach (PlatformSegmentDestroy segmentDestroy in _segmentDestroy)
                segmentDestroy.Break(_config.ExplosionForce, transform.position, _config.ExplosionRadius);

            Destroy(gameObject, _config.LifetimeAfterDestruction);
        }
    }
}