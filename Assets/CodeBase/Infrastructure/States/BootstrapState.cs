using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Logic;
using CodeBase.Services;
using CodeBase.Services.Cleanup;
using CodeBase.Services.Factory;
using CodeBase.Services.Input;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.Observers.LevelMapObserver;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.UIFactory;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(GameConstants.InitScene, OnLoaded);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            RegisterStaticData();
            _services.RegisterSingle<ILevelMapObserverService>(new LevelMapObserverService());
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactoryService>(new GameFactoryServiceService(_services));
            _services.RegisterSingle<ILogicFactoryService>(new LogicFactoryService(_services));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services));
            _services.RegisterSingle<ICleanupService>(new CleanupService(_services.Single<ILogicFactoryService>(), _services.Single<ILevelMapObserverService>()));
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadLevelMapState>();
        }

        private void RegisterStaticData()
        {
            var service = new StaticDataService();
            service.Load();
            _services.RegisterSingle<IStaticDataService>(service);
        }
    }
}