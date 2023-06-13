using CodeBase.Infrastructure.Logic;
using CodeBase.Services;
using CodeBase.Services.Factory;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.UIFactory;
using System;
using System.Collections.Generic;
using CodeBase.Services.Cleanup;
using CodeBase.Services.Observers.LevelMapObserver;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitable> _states;
        private IExitable _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadCurtain loadCurtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitable>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelMapState)] = new LoadLevelMapState(this, sceneLoader, loadCurtain,
                    services.Single<IUIFactory>(), 
                    services.Single<ILevelMapObserverService>(),
                    services.Single<ICleanupService>(),
                    services.Single<IStaticDataService>()),

                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadCurtain,
                    services.Single<ILogicFactoryService>(),
                    services.Single<IStaticDataService>(),
                    services.Single<IGameFactoryService>(),
                    services.Single<ICleanupService>()),

                [typeof(LoopState)] = new LoopState(),
            };
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitable
        {
            _activeState?.Exit();
            TState state = _states[typeof(TState)] as TState;
            _activeState = state;
            return state;
        }
    }
}