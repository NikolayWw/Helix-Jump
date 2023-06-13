using CodeBase.StaticData.Camera;
using CodeBase.StaticData.Level;
using CodeBase.StaticData.Platform;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Tower;

namespace CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();

        LevelConfig ForLevel(LevelId id);

        TowerStaticData TowerStaticData { get; }
        PlayerStaticData PlayerStaticData { get; }
        PlatformStaticData PlatformStaticData { get; }
        CameraStaticData CameraStaticData { get; }
    }
}