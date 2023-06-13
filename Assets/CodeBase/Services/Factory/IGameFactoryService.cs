using UnityEngine;

namespace CodeBase.Services.Factory
{
    public interface IGameFactoryService : IService
    {
        GameObject CreateTower(GameObject towerPrefab);
        GameObject CreatePlatform(GameObject platform);
        GameObject CreatePlayer(Vector3 at);
    }
}