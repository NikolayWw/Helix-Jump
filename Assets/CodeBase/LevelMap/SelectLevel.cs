using CodeBase.Services;
using CodeBase.Services.Observers.LevelMapObserver;
using CodeBase.StaticData.Level;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.LevelMap
{
    public class SelectLevel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LevelId _levelId;
        [SerializeField] private Transform _pointPosition;

        private ILevelMapObserverService _observerService;

        private void Start()
        {
            _observerService = AllServices.Container.Single<ILevelMapObserverService>();
        }

        public void OnPointerClick(PointerEventData eventData) => 
            _observerService.SendSelectedLevel(_levelId, _pointPosition.position);
    }
}