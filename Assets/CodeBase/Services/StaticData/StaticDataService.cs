using CodeBase.StaticData.Level;
using CodeBase.StaticData.Platform;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Tower;
using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Camera;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string LevelsStaticDataPath = "StaticData/LevelsStaticData";
        private const string TowerStaticDataPath = "StaticData/TowerStaticData";
        private const string PlayerStaticDataPath = "StaticData/PlayerStaticData";
        private const string PlatformStaticDataPath = "StaticData/PlatformStaticData";
        private const string CameraStaticDataPath = "StaticData/CameraStaticData";

        private Dictionary<LevelId, LevelConfig> _levelConfigs;

        public TowerStaticData TowerStaticData { get; private set; }
        public PlayerStaticData PlayerStaticData { get; private set; }
        public PlatformStaticData PlatformStaticData { get; private set; }
        public CameraStaticData CameraStaticData { get; private set; }

        public void Load()
        {
            _levelConfigs = Resources.Load<LevelsStaticData>(LevelsStaticDataPath).LevelConfigs.ToDictionary(x => x.LevelId, x => x);
            TowerStaticData = Resources.Load<TowerStaticData>(TowerStaticDataPath);
            PlayerStaticData = Resources.Load<PlayerStaticData>(PlayerStaticDataPath);
            PlatformStaticData = Resources.Load<PlatformStaticData>(PlatformStaticDataPath);
            CameraStaticData = Resources.Load<CameraStaticData>(CameraStaticDataPath);
        }

        public LevelConfig ForLevel(LevelId id) => 
            _levelConfigs.TryGetValue(id, out var cfg) ? cfg : null;
    }
}