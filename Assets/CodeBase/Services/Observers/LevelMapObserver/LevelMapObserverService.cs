using System;
using CodeBase.StaticData.Level;
using UnityEngine;

namespace CodeBase.Services.Observers.LevelMapObserver
{
    public class LevelMapObserverService : ILevelMapObserverService
    {
        public Action<LevelId, Vector3> OnSelectedLevel { get; set; }

        public void Cleanup()
        {
            OnSelectedLevel = null;
        }

        public void SendSelectedLevel(LevelId levelKey, Vector3 position) =>
            OnSelectedLevel?.Invoke(levelKey, position);
    }
}