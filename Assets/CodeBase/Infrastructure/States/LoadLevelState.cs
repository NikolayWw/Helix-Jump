using CodeBase.Camera;
using CodeBase.Data;
using CodeBase.Infrastructure.Logic;
using CodeBase.Services.Cleanup;
using CodeBase.Services.Factory;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Level;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<LevelId>
    {
        private const string PlayerInitialPointTag = "PlayerInitialPoint";
        private readonly ICleanupService _cleanupService;
        private readonly IStaticDataService _dataService;
        private readonly IGameFactoryService _gameFactory;
        private readonly LoadCurtain _loadingCurtain;
        private readonly ILogicFactoryService _logicFactory;
        private readonly SceneLoader _sceneLoader;

        private readonly IGameStateMachine _stateMachine;

        private LevelId _activeSceneId;

        public LoadLevelState(IGameStateMachine stateMachine, SceneLoader sceneLoader, LoadCurtain loadingCurtain,
            ILogicFactoryService logicFactory, IStaticDataService dataService, IGameFactoryService gameFactory,
            ICleanupService cleanupService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _logicFactory = logicFactory;
            _dataService = dataService;
            _gameFactory = gameFactory;
            _cleanupService = cleanupService;
        }

        public void Enter(LevelId sceneId)
        {
            _activeSceneId = sceneId;
            _cleanupService.Cleanup();
            _loadingCurtain.Show();
            _sceneLoader.Load(GameConstants.MainSceneKey, OnLoaded);
        }


        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            GetLevelConfig(out var levelConfig);

            _logicFactory.InitializeTowerBuilder(levelConfig);
            _logicFactory.InitializePlatformBuilder(levelConfig);

            _logicFactory.TowerBuilder.Build();
            _logicFactory.PlatformBuilder.Build();

            var player =
                _gameFactory.CreatePlayer(GameObject.FindGameObjectWithTag(PlayerInitialPointTag).transform.position);
            CameraFollow(player.transform);

            _stateMachine.Enter<LoopState>();
        }

        private static void CameraFollow(Transform target)
        {
            UnityEngine.Camera.main.GetComponent<CameraFollow>()?.SetTarget(target);
        }

        private void GetLevelConfig(out LevelConfig config)
        {
            config = _dataService.ForLevel(_activeSceneId);
            if (config == null)
                Debug.LogError("Level configuration or level key missing");
        }
    }
}