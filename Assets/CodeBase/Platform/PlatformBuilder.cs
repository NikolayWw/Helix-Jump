using CodeBase.Services.Factory;
using CodeBase.StaticData.Level;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Platform
{
    public class PlatformBuilder
    {
        private readonly IGameFactoryService _gameFactory;
        private readonly LevelConfig _levelConfig;
        private readonly TowerBuilder _towerBuilder;

        public PlatformBuilder(LevelConfig levelConfig, IGameFactoryService gameFactory, TowerBuilder towerBuilder)
        {
            _gameFactory = gameFactory;
            _towerBuilder = towerBuilder;
            _levelConfig = levelConfig;
        }

        public void Build()
        {
            for (var i = 0; i < _levelConfig.TowerHeight; i++)
            {
                GameObject prefab = _levelConfig.Platforms[Random.Range(0, _levelConfig.Platforms.Length)];
                Transform platformTransform = _gameFactory.CreatePlatform(prefab).transform;
                platformTransform.position += Vector3.down * i;
                platformTransform.SetParent(_towerBuilder.TowerTransform);
            }
        }
    }
}