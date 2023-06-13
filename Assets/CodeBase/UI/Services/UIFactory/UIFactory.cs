using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using CodeBase.Services;
using CodeBase.Services.Observers.LevelMapObserver;
using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.UI.Services.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private readonly AllServices _services;
        private Transform _root;

        public UIFactory(AllServices services)
        {
            _services = services;
        }

        public void CreateUIRoot()
        {
            _root = Object.Instantiate(Resources.Load<GameObject>(AssetsPath.UIRoot).transform);
        }

        public void CreateLevelTransferButton()
        {
            GameObject prefab = Resources.Load<GameObject>(AssetsPath.UILevelTransferButton);
            GameObject instance = Object.Instantiate(prefab, _root);
            instance.GetComponent<LevelTransferButton>()?.Construct(Service<ILevelMapObserverService>(), Service<IGameStateMachine>());
        }

        private TService Service<TService>() where TService : IService
        {
            return _services.Single<TService>();
        }
    }
}