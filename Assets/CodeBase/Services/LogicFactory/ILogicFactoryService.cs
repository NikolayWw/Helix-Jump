using CodeBase.Platform;
using CodeBase.StaticData.Level;
using CodeBase.Tower;

namespace CodeBase.Services.LogicFactory
{
    public interface ILogicFactoryService : IService
    {
        void Cleanup();

        void InitializeTowerBuilder(LevelConfig levelConfig);

        void InitializePlatformBuilder(LevelConfig levelConfig);

        TowerBuilder TowerBuilder { get; }
        PlatformBuilder PlatformBuilder { get; }
    }
}