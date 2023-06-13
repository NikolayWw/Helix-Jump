using CodeBase.Camera;
using CodeBase.Data;
using CodeBase.Infrastructure.Logic;
using CodeBase.Services.Cleanup;
using CodeBase.Services.Observers.LevelMapObserver;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.UIFactory;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelMapState : IState
    {
        private readonly ICleanupService _cleanupService;
        private readonly ILevelMapObserverService _levelMapObserver;

        private readonly LoadCurtain _loadCurtain;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;

        public LoadLevelMapState(IGameStateMachine stateMachine, SceneLoader sceneLoader, LoadCurtain loadCurtain,
            IUIFactory uiFactory, ILevelMapObserverService levelMapObserverService, ICleanupService cleanupService,
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadCurtain = loadCurtain;
            _uiFactory = uiFactory;
            _levelMapObserver = levelMapObserverService;
            _cleanupService = cleanupService;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _cleanupService.Cleanup();
            _loadCurtain.Show();
            _sceneLoader.Load(GameConstants.MapLevelKey, OnLoaded);
        }

        public void Exit()
        {
            _loadCurtain.Hide();
        }

        private void OnLoaded()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateLevelTransferButton();
            InitializeCamera();
            _stateMachine.Enter<LoopState>();
        }

        private void InitializeCamera()
        {
            var mainCamera = UnityEngine.Camera.main;
            if (mainCamera != null)
                mainCamera.gameObject.GetComponent<CameraFollowLevelMap>()
                    ?.Construct(_levelMapObserver, _staticDataService);
        }
    }
}