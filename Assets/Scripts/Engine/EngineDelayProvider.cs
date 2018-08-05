using DataContainer;
using Extensions;
using Models;
using PlayerManager;

namespace Engine
{
    public class EngineDelayProvider
    {
        private readonly IContainer<Player> _playerContainer;
        public EngineDelayProvider()
        {
            _playerContainer = PlayerController.PlayerContainer;
        }

        public float ProvideDelay(EngineNumber engineNumber)
        {
            return _playerContainer.Data.LevelEngineSettings.GetEngineValue(UnitOfWork.LevelNumber,
                UnitOfWork.PointNumber,
                ((int)engineNumber).ToString()).Delay;
        }
    }
}