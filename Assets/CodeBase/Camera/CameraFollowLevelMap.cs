using System.Collections;
using CodeBase.Services.Observers.LevelMapObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Camera;
using CodeBase.StaticData.Level;
using UnityEngine;

namespace CodeBase.Camera
{
    public class CameraFollowLevelMap : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private CameraStaticData _config;

        private ILevelMapObserverService _observerService;

        private void OnDestroy()
        {
            if (_observerService != null)
                _observerService.OnSelectedLevel -= StartMove;
        }

        public void Construct(ILevelMapObserverService observerService, IStaticDataService staticDataService)
        {
            _observerService = observerService;
            _config = staticDataService.CameraStaticData;
            _observerService.OnSelectedLevel += StartMove;
        }

        private void StartMove(LevelId levelId, Vector3 position)
        {
            StopAllCoroutines();
            StartCoroutine(Move(position));
        }


        private IEnumerator Move(Vector3 targetPosition)
        {
            targetPosition += _offset;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition,
                    _config.LevelMapMoveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}