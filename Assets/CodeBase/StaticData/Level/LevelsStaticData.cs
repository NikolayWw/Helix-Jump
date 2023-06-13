using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Level
{
    [CreateAssetMenu(menuName = "Static Data/Levels Static Data", order = 0)]
    public class LevelsStaticData : ScriptableObject
    {
        public List<LevelConfig> LevelConfigs;

        private void OnValidate()
        {
            LevelConfigs.ForEach(x => x.OnValidate());
        }
    }
}