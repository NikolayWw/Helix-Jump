using CodeBase.Platform;
using CodeBase.Services.Factory;
using CodeBase.StaticData.Level;
using CodeBase.Tower;

namespace CodeBase.Services.LogicFactory
{
    public class LogicFactoryService : ILogicFactoryService
    {
        private readonly AllServices _services;

        public TowerBuilder TowerBuilder { get; private set; }
        public PlatformBuilder PlatformBuilder { get; private set; }

        public LogicFactoryService(AllServices services)
        {
            _services = services;
        }

        public void Cleanup()
        {
            TowerBuilder = null;
            PlatformBuilder = null;
        }

        public void InitializeTowerBuilder(LevelConfig levelConfig) =>
            TowerBuilder = new TowerBuilder(levelConfig, Service<IGameFactoryService>());

        public void InitializePlatformBuilder(LevelConfig levelConfig) =>
            PlatformBuilder = new PlatformBuilder(levelConfig, Service<IGameFactoryService>(), TowerBuilder);

        private TService Service<TService>() where TService : IService =>
            _services.Single<TService>();
    }
}