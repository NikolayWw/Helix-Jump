using CodeBase.Services.Factory;
using CodeBase.StaticData.Level;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerBuilder
    {
        private readonly LevelConfig _levelConfig;
        private readonly IGameFactoryService _gameFactory;
        public Transform TowerTransform { get; private set; }

        public TowerBuilder(LevelConfig levelConfig, IGameFactoryService gameFactory)
        {
            _levelConfig = levelConfig;
            _gameFactory = gameFactory;
        }

        public void Build()
        {
            GameObject instance = _gameFactory.CreateTower(_levelConfig.TowerPrefab);
            instance.GetComponent<TowerHeight>()?.SetHeight(_levelConfig.TowerHeight);
            TowerTransform = instance.transform;
        }
    }
}