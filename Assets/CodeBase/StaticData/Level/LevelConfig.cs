using System;
using UnityEngine;

namespace CodeBase.StaticData.Level
{
    [Serializable]
    public class LevelConfig
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public LevelId LevelId { get; private set; }
        [field: SerializeField] public int TowerHeight { get; private set; } = 1;
        [field: SerializeField] public GameObject TowerPrefab { get; private set; }
        [field: SerializeField] public GameObject[] Platforms { get; private set; }

        public void OnValidate()
        {
            _inspectorName = LevelId.ToString();
            if (TowerHeight < 1) TowerHeight = 1;
        }
    }
}