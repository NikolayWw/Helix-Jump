using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Platform;
using CodeBase.Player;
using CodeBase.Services.Input;
using CodeBase.Services.StaticData;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Services.Factory
{
    public class GameFactoryServiceService : IGameFactoryService
    {
        private readonly AllServices _services;

        public GameFactoryServiceService(AllServices services)
        {
            _services = services;
        }

        public GameObject CreateTower(GameObject towerPrefab)
        {
            var instance = Object.Instantiate(towerPrefab);
            instance.GetComponent<TowerRotate>()?.Construct(Service<IInputService>(), Service<IStaticDataService>());
            return instance;
        }

        public GameObject CreatePlatform(GameObject platform)
        {
            GameObject instance = Object.Instantiate(platform);
            instance.GetComponent<PlatformGroupBreak>()?.Construct(Service<IStaticDataService>());
            return instance;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            GameObject instance = Service<IAssetProvider>().Instantiate(AssetsPath.Player, at);
            instance.GetComponent<PlayerMove>()?.Construct(Service<IStaticDataService>());
            return instance;
        }

        private TService Service<TService>() where TService : IService =>
            _services.Single<TService>();
    }
}