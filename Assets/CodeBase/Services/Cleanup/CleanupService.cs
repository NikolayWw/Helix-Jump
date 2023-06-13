using CodeBase.Services.LogicFactory;
using CodeBase.Services.Observers.LevelMapObserver;

namespace CodeBase.Services.Cleanup
{
    public class CleanupService : ICleanupService
    {
        private readonly ILogicFactoryService _logicFactoryService;
        private readonly ILevelMapObserverService _levelMapObserverService;

        public CleanupService(ILogicFactoryService logicFactoryService, ILevelMapObserverService levelMapObserverService)
        {
            _logicFactoryService = logicFactoryService;
            _levelMapObserverService = levelMapObserverService;
        }

        public void Cleanup()
        {
            _levelMapObserverService.Cleanup();
            _logicFactoryService.Cleanup();
        }
    }
}