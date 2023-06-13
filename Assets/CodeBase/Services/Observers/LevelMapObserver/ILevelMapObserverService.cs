using System;
using CodeBase.StaticData.Level;
using UnityEngine;

namespace CodeBase.Services.Observers.LevelMapObserver
{
    public interface ILevelMapObserverService : IService
    {
        Action<LevelId, Vector3> OnSelectedLevel { get; set; }

        void SendSelectedLevel(LevelId levelKey, Vector3 position);
        void Cleanup();
    }
}