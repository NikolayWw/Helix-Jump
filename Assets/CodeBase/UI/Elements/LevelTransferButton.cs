using CodeBase.Infrastructure.States;
using CodeBase.Services.Observers.LevelMapObserver;
using CodeBase.StaticData.Level;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class LevelTransferButton : MonoBehaviour
    {
        [SerializeField] private Button _transferButton;
        private LevelId _currentLeveId = LevelId.Level1;

        private IGameStateMachine _gameStateMachine;
        private ILevelMapObserverService _observerService;

        public void Construct(ILevelMapObserverService observerService, IGameStateMachine gameStateMachine)
        {
            _observerService = observerService;
            _gameStateMachine = gameStateMachine;
            _observerService.OnSelectedLevel += RefreshButton;
            _transferButton.onClick.AddListener(Transfer);
        }

        private void RefreshButton(LevelId levelId, Vector3 position)
        {
            _currentLeveId = levelId;
        }

        private void Transfer()
        {
            _gameStateMachine.Enter<LoadLevelState, LevelId>(_currentLeveId);
        }
    }
}